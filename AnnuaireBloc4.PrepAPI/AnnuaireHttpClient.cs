using AnnuaireBloc4.Domain;
using AnnuaireBloc4.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.PrepAPI
{
	// TODO CHECK RESULT CODE
	public class AnnuaireHttpClient : HttpClient
	{
		public AnnuaireHttpClient()
		{
			this.BaseAddress = new Uri("https://localhost:5001/api/");
		}

		/*
		 * Get
		 */
		public async Task<T>	GetAsync<T>(string uri)
		{
			HttpResponseMessage response = await GetAsync(uri);
			string jsonResponse = await response.Content.ReadAsStringAsync();
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
			{
				var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);
				var errors = result.GetValueOrDefault("errors");
				throw new ApiException(result.GetValueOrDefault("title")?.ToString(), CleanString(errors.ToString()));
			}
			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}

		/*
		 * Create 
		 */
		public async Task<T> PostAsync<U, T>(string uri, U elem) where U : IApiModel
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(elem), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await PostAsync(uri, content);
			string jsonResponse = await response.Content.ReadAsStringAsync();
			if (response.StatusCode != System.Net.HttpStatusCode.Created)
			{
				var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);
				var errors = result.GetValueOrDefault("errors");
				throw new ApiException(result.GetValueOrDefault("title")?.ToString(), CleanString(errors.ToString()));
			}
			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}

		/*
		 * Update 
		 */
		public async Task<int> PutAsync<U, T>(string uri, U elem) where U : IApiModel
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(elem), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await PutAsync(uri, content);
			if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);
				var errors = result.GetValueOrDefault("errors");
				throw new ApiException(result.GetValueOrDefault("title")?.ToString(), CleanString(errors.ToString()));
			}
			return (int)response.StatusCode;
		}

		/*
		 * Delete 
		 */
		public async Task<int> CustomDeleteAsync(string uri)
		{
			HttpResponseMessage response = await DeleteAsync(uri);
			if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);
				var errors = result.GetValueOrDefault("errors");
				throw new ApiException(result.GetValueOrDefault("title")?.ToString(), CleanString(errors.ToString()));
			}
			return (int)response.StatusCode;
		}

		private string CleanString(string s)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in s)
			{
				if (c != '{' && c != '}' && c != '"' && c != ',' && c != '[' && c != ']')
				{
					sb.Append(c);
				}
			}
			return sb.ToString().Replace(": \r\n", ":").Replace("\r\n \r\n", "\r\n").Replace("    ", " ");
		}
	}
}

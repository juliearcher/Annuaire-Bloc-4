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

		public async Task<T>	GetAsync<T>(string uri)
		{
			HttpResponseMessage response = await GetAsync(uri);
			string jsonResponse = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}

		public async Task<T> PostAsync<U, T>(string uri, U elem) where U : IApiModel
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(elem), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await PostAsync(uri, content);
			string jsonResponse = await response.Content.ReadAsStringAsync();
			if ((int)response.StatusCode != 201)
			{
				var error = JsonConvert.DeserializeObject<ApiError>(jsonResponse);
				if (error.Errors == null)
				{
					throw new ApiException(error.Title);
				}
				else
				{
					throw new ApiException(error.Errors.ToString());
				}
			}
			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}

		public async Task<int> PutAsync<U, T>(string uri, U elem) where U : IApiModel
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(elem), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await PutAsync(uri, content);
			if ((int)response.StatusCode != 204)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var error = JsonConvert.DeserializeObject<ApiError>(jsonResponse);
				if (error.Errors == null)
				{
					throw new ApiException(error.Title);
				}
				else
				{
					throw new ApiException(error.Errors.ToString());
				}
			}
			return (int)response.StatusCode;
		}

		public async Task<int> CustomDeleteAsync(string uri)
		{
			HttpResponseMessage response = await DeleteAsync(uri);
			if ((int)response.StatusCode != 204)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				var error = JsonConvert.DeserializeObject<ApiError>(jsonResponse);
				if (error.Errors == null)
				{
					throw new ApiException(error.Title);
				}
				else
				{
					throw new ApiException(error.Errors.ToString());
				}
			}
			return (int)response.StatusCode;
		}
	}
}

using AnnuaireBloc4.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.PrepAPI
{
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

			var response = await PostAsync(uri, content);
			string jsonResponse = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(jsonResponse);
		}
	}
}

using Newtonsoft.Json;
using System;
using System.Net.Http;
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
	}
}

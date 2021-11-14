using Annuaire_Bloc_4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Services
{
	public class ServicesService : IServicesService
	{
		public async Task<IEnumerable<Service>> GetAllServices()
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/services");
				string jsonResponse = await response.Content.ReadAsStringAsync();

				IEnumerable<Service> serviceList = JsonConvert.DeserializeObject<IEnumerable<Service>>(jsonResponse);
				return serviceList;
			}
		}

		public async Task<Service> GetServiceById(int id)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/services/" + id);
				string jsonResponse = await response.Content.ReadAsStringAsync();

				Service service = JsonConvert.DeserializeObject<Service>(jsonResponse);
				return service;
			}
		}
	}
}

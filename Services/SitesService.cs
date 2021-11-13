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
	public class SitesService : ISitesService
	{
		public async Task<IEnumerable<Site>> GetAllSites()
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/sites");
				string jsonResponse = await response.Content.ReadAsStringAsync();

				IEnumerable<Site> siteList = JsonConvert.DeserializeObject<IEnumerable<Site>>(jsonResponse);
				return siteList;
			}
		}

		public async Task<Site> GetSiteById(int id)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/sites/" + id);
				string jsonResponse = await response.Content.ReadAsStringAsync();

				Site site = JsonConvert.DeserializeObject<Site>(jsonResponse);
				return site;
			}
		}
	}
}

using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.PrepAPI.Services
{
	public class SitesService : ISitesService
	{
		public async Task<IEnumerable<Site>> GetAllSites()
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var siteList = await client.GetAsync<IEnumerable<Site>>("sites");
				return siteList;
			}
		}

		public async Task<Site> GetSiteById(int id)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var site = await client.GetAsync<Site>("sites/" + id);
				return site;
			}
		}

		public async Task<Site> CreateSite(Site site)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var response = await client.PostAsync<Site, Site>("sites/", site);
				return response;
			}
		}
	}
}

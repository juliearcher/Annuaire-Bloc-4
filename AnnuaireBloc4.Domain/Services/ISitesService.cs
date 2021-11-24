using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Services
{
	public interface ISitesService
	{
		Task<IEnumerable<Site>> GetAllSites();
		Task<Site> GetSiteById(long id);
		Task<Site> CreateSite(Site site);
		Task<bool> UpdateSite(Site site);
	}
}

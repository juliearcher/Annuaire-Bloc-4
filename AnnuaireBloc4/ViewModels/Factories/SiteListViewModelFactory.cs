using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class SiteListViewModelFactory : IViewModelFactory<SiteListViewModel>
	{
		private readonly ISitesService _siteService;

		public SiteListViewModelFactory(ISitesService sitesService)
		{
			_siteService = sitesService;
		}

		public SiteListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return SiteListViewModel.LoadSiteListViewModel(_siteService, factory);
		}
	}
}

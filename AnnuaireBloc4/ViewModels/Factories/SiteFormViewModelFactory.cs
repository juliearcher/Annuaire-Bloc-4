using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class SiteFormViewModelFactory : IViewModelFormFactory<SiteFormViewModel>
	{
		private readonly ISitesService _siteService;

		public SiteFormViewModelFactory(ISitesService sitesService)
		{
			_siteService = sitesService;
		}

		public SiteFormViewModel CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem)
		{
			return new SiteFormViewModel(_siteService, viewModelBase, (Site)elem);
		}
	}
}

using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AutoMapper;
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
		private IMapper _mapper;

		public SiteFormViewModelFactory(ISitesService sitesService, IMapper mapper)
		{
			_siteService = sitesService;
			_mapper = mapper;
		}

		public SiteFormViewModel CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem)
		{
			return new SiteFormViewModel(_siteService, _mapper, viewModelBase, (Site)elem);
		}
	}
}

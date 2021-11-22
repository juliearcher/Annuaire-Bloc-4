using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class SiteFormViewModel : ViewModelBase
	{
		private readonly ISitesService _sitesService;
		public Site Site { get; }

		public SiteFormViewModel(ISitesService sitesService, Site site)
		{
			_sitesService = sitesService;
			Site = site;
		}
	}
}

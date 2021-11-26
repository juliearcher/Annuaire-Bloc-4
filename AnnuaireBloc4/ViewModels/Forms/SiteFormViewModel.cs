using AnnuaireBloc4.Domain;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnnuaireBloc4.ViewModels
{
	public class SiteFormViewModel : FormViewModelBase
	{
		private readonly ISitesService _sitesService;
		private Site _site;
		public Site Site
		{
			get
			{
				return _site;
			}
			set
			{
				_site = value;
				OnPropertyChanged(nameof(Site));
			}
		}

		public SiteFormViewModel(ISitesService sitesService, ListViewModelBase listViewModelBase, Site site)
		{
			_sitesService = sitesService;
			ListViewModelBase = listViewModelBase;
			_mode = site == null ? EditMode.CREATE : EditMode.UPDATE;
			Site = site ?? new Site();
		}

		public async override Task<bool> SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				await _sitesService.CreateSite(Site);
			}
			else
			{
				await _sitesService.UpdateSite(Site);
			}
			return true;
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}

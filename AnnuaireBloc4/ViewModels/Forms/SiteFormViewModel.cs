using AnnuaireBloc4.Domain;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

		public SiteFormViewModel(ISitesService sitesService, ListViewModelBase listViewModelBase, Site site)
		{
			_sitesService = sitesService;
			ListViewModelBase = listViewModelBase;
			_mode = site == null ? EditMode.CREATE : EditMode.UPDATE;
			_site = site ?? new Site();
			NewElem = new SiteDataError(_site);
		}

		public async override Task<bool> SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				await _sitesService.CreateSite(_site);
			}
			else
			{
				await _sitesService.UpdateSite(_site);
			}
			return true;
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}

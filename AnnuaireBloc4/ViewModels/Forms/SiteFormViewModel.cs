using AnnuaireBloc4.Domain;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.Models;
using AutoMapper;
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

		public SiteFormViewModel(ISitesService sitesService, IMapper mapper, ListViewModelBase listViewModelBase, Site site)
		{
			_sitesService = sitesService;
			_mapper = mapper;
			ListViewModelBase = listViewModelBase;
			_mode = site == null ? EditMode.CREATE : EditMode.UPDATE;
			NewElem = new SiteDataError(site ?? new Site());
		}

		public async override Task<bool> SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				Site newSite = await _sitesService.CreateSite(_mapper.Map<Site>(NewElem));
				(NewElem as SiteDataError).Id = newSite.Id;
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _sitesService.UpdateSite(_mapper.Map<Site>(NewElem));
			}
			return true;
		}

		public override bool IsValid()
		{
			return NewElem.CanCreate;
		}
	}
}

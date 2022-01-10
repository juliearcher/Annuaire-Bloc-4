using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public class SiteListViewModel : ListViewModelBase
	{
		private readonly ISitesService _sitesService;

		private IEnumerable<Site> _siteInitialList;
		private IEnumerable<Site> _siteList;
		public IEnumerable<Site> SiteList
		{
			get
			{
				return _siteList;
			}
			set
			{
				if (value != null)
				{
					_siteList = value;
					OnPropertyChanged(nameof(SiteList));
				}
			}
		}

		/*
		 *  Search in city name
		 */
		private string _searchFilter;
		public string SearchFilter
		{
			get
			{
				return _searchFilter;
			}
			set
			{
				if (_searchFilter != value)
				{
					_searchFilter = value.ToLower();
					SiteList = _siteInitialList.Where(d => d.City.ToLower().Contains(_searchFilter ?? ""));
					OnPropertyChanged(nameof(SearchFilter));
				}
			}
		}

		public SiteListViewModel(ISitesService sitesService, IViewModelAbstractFactory viewModelFactory)
		{
			_sitesService = sitesService;
			_siteInitialList = new ObservableCollection<Site>();
			ViewModelFactory = viewModelFactory;
		}

		public static SiteListViewModel LoadSiteListViewModel(ISitesService sitesServices, IViewModelAbstractFactory viewModelFactory)
		{
			SiteListViewModel sitesListViewModel = new SiteListViewModel(sitesServices, viewModelFactory);
			sitesListViewModel.LoadSites();
			return sitesListViewModel;
		}

		private void LoadSites()
		{
			_sitesService.GetAllSites().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					_siteInitialList = task.Result;
					SiteList = _siteInitialList.Where(d => d.City.ToLower().Contains(_searchFilter ?? ""));
				}
			});
		}
		override public void LoadList()
		{
			this.LoadSites();
		}

		override public async Task<bool> DeleteSelectedItem()
		{
			return await _sitesService.DeleteSite(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}

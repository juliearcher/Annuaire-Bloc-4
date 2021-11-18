using Annuaire_Bloc_4.Commands;
using Annuaire_Bloc_4.Domain.Models;
using Annuaire_Bloc_4.Domain.Services;
using Annuaire_Bloc_4.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.ViewModels
{
	public class SiteListViewModel : ViewModelBase, IListViewModel
	{
		public IApiModel SelectedItem { get; set; }

		private readonly ISitesService _sitesService;

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

		public SiteListViewModel(ISitesService sitesService)
		{
			_sitesService = sitesService;
			SiteList = new ObservableCollection<Site>();
		}

		public static SiteListViewModel LoadSiteListViewModel(ISitesService sitesServices)
		{
			SiteListViewModel sitesListViewModel = new SiteListViewModel(sitesServices);
			sitesListViewModel.LoadSites();
			return sitesListViewModel;
		}

		private void LoadSites()
		{
			_sitesService.GetAllSites().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					SiteList = task.Result;
				}
			});
		}

		public ICommand AddNewElement => new AddNewElement(this);

		public ICommand UpdateElement => new UpdateElement(this);

		public ICommand DeleteElement => new DeleteElement(this);
	}
}

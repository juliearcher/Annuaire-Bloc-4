using Annuaire_Bloc_4.Models;
using Annuaire_Bloc_4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.ViewModels
{
	public class SiteListViewModel : ViewModelBase
	{
		private readonly ISitesService _sitesServices;

		public IEnumerable<Site> SiteList
		{
			get
			{
				return SiteList;
			}
			set
			{
				SiteList = value;
				OnPropertyChanged(nameof(SiteList));
			}
		}

		public SiteListViewModel(ISitesService sitesServices)
		{
			_sitesServices = sitesServices;
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
			_sitesServices.GetAllSites().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					SiteList = task.Result;
				}
			});
		}
	}
}

using Annuaire_Bloc_4.Models;
using Annuaire_Bloc_4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.ViewsModels
{
	public class SitesViewModel : ViewModelBase
	{
		private readonly ISitesService		_sitesServices;

		public IEnumerable<Site> SiteList { get; set; } = new ObservableCollection<Site>();

		public SitesViewModel(ISitesService sitesServices)
		{
			_sitesServices = sitesServices;
		}

		public static SitesViewModel	LoadSitesViewModel(ISitesService sitesServices)
		{
			SitesViewModel sitesViewModel = new SitesViewModel(sitesServices);
			sitesViewModel.LoadSites();
			return sitesViewModel;
		}

		private void LoadSites()
		{
			_sitesServices.GetAllSites().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					SiteList = task.Result;
					OnPropertyChanged(nameof(SiteList));
				}
			});
		}
	}
}

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
	public class SitesViewModel : ViewModelBase
	{
		public SiteListViewModel SiteListViewModel { get; set; }

		public SitesViewModel(SiteListViewModel sitesListViewModel)
		{
			SiteListViewModel = sitesListViewModel;
		}
	}
}

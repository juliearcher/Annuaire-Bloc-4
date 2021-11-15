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
		public SitesListViewModel SitesListViewModel { get; set; }

		public SitesViewModel(SitesListViewModel sitesListViewModel)
		{
			SitesListViewModel = sitesListViewModel;
		}
	}
}

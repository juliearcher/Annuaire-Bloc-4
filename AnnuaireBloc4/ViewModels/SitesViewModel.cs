using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
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

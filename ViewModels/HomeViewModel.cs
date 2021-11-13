﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.ViewsModels
{
	public class HomeViewModel : ViewModelBase
	{
		public SitesViewModel SitesViewModel { get; set; }

		public HomeViewModel(SitesViewModel sitesViewModel)
		{
			SitesViewModel = sitesViewModel;
		}
	}
}

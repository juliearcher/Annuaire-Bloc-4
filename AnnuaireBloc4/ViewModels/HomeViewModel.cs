using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public SiteListViewModel SiteListViewModel { get; set; }

		public DepartmentListViewModel DepartmentListViewModel { get; set; }

		public HomeViewModel(SiteListViewModel sitesListViewModel, DepartmentListViewModel departmentListViewModel)
		{
			SiteListViewModel = sitesListViewModel;
			DepartmentListViewModel = departmentListViewModel;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
	{
		private IViewModelFactory<SiteListViewModel> _siteListViewModelFactory;
		private IViewModelFactory<DepartmentListViewModel> _departmentListViewModelFactory;

		public HomeViewModelFactory(IViewModelFactory<SiteListViewModel> siteListViewModelFactory, IViewModelFactory<DepartmentListViewModel> departmentListViewModelFactory)
		{
			_siteListViewModelFactory = siteListViewModelFactory;
			_departmentListViewModelFactory = departmentListViewModelFactory;
		}

		public HomeViewModel CreateViewModel()
		{
			return new HomeViewModel(_siteListViewModelFactory.CreateViewModel(), _departmentListViewModelFactory.CreateViewModel());
		}
	}
}

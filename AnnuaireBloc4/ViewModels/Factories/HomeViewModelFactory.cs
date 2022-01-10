using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	class HomeViewModelFactory : IViewModelListFactory<HomeViewModel>
	{
		private IViewModelListFactory<SiteListViewModel> _siteListViewModelFactory;
		private IViewModelListFactory<DepartmentListViewModel> _departmentListViewModelFactory;

		/*
		 * Get required services
		 */
		public HomeViewModelFactory(IViewModelListFactory<SiteListViewModel> siteListViewModelFactory, IViewModelListFactory<DepartmentListViewModel> departmentListViewModelFactory)
		{
			_siteListViewModelFactory = siteListViewModelFactory;
			_departmentListViewModelFactory = departmentListViewModelFactory;
		}

		/*
		 * Create ViewModel (called by main factory)
		 */
		public HomeViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new HomeViewModel(_siteListViewModelFactory.CreateViewModel(factory), _departmentListViewModelFactory.CreateViewModel(factory));
		}
	}
}

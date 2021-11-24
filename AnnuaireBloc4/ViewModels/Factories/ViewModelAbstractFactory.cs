using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class ViewModelAbstractFactory : IViewModelAbstractFactory
	{
		private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
		private readonly IViewModelFactory<EmployeesViewModel> _employeesViewModelFactory;
		private readonly IViewModelFormFactory<SiteFormViewModel> _siteFormViewModelFactory;

		public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory, IViewModelFactory<EmployeesViewModel> employeesViewModelFactory, IViewModelFormFactory<SiteFormViewModel> siteFormViewModelFactory)
		{
			_homeViewModelFactory = homeViewModelFactory;
			_employeesViewModelFactory = employeesViewModelFactory;
			_siteFormViewModelFactory = siteFormViewModelFactory;
		}

		public ViewModelBase CreateFormViewModel(ListViewModelBase viewModelBase, ViewType viewType, IApiModel elem)
		{
			switch (viewType)
			{
				case ViewType.SiteForm:
					return _siteFormViewModelFactory.CreateViewModel(viewModelBase, elem);
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
		}

		public ViewModelBase CreateViewModel(ViewType viewType)
		{
			switch (viewType)
			{
				case ViewType.Home:
					return _homeViewModelFactory.CreateViewModel(this);
				case ViewType.Employees:
					return _employeesViewModelFactory.CreateViewModel(this);
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
		}
	}
}

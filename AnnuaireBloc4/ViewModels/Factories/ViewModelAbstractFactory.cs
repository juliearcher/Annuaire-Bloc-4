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
		private readonly IViewModelListFactory<HomeViewModel> _homeViewModelFactory;
		private readonly IViewModelListFactory<EmployeesViewModel> _employeesViewModelFactory;
		private readonly IViewModelFormFactory<SiteFormViewModel> _siteFormViewModelFactory;
		private readonly IViewModelFormFactory<DepartmentFormViewModel> _departmentFormViewModelFactory;
		private readonly IViewModelFormFactory<EmployeeFormViewModel> _employeeFormViewModelFactory;

		/*
		 * Add all viewmodel factories to main factory
		 */
		public ViewModelAbstractFactory(IViewModelListFactory<HomeViewModel> homeViewModelFactory, IViewModelListFactory<EmployeesViewModel> employeesViewModelFactory, IViewModelFormFactory<SiteFormViewModel> siteFormViewModelFactory, IViewModelFormFactory<DepartmentFormViewModel> departmentFormViewModelFactory, IViewModelFormFactory<EmployeeFormViewModel> employeeFormViewModelFactory)
		{
			_homeViewModelFactory = homeViewModelFactory;
			_employeesViewModelFactory = employeesViewModelFactory;
			_siteFormViewModelFactory = siteFormViewModelFactory;
			_departmentFormViewModelFactory = departmentFormViewModelFactory;
			_employeeFormViewModelFactory = employeeFormViewModelFactory;
		}

		/*
		 * Creates Form ViewModels
		 */
		public ViewModelBase CreateFormViewModel(ListViewModelBase viewModelBase, ViewType viewType, IApiModel elem)
		{
			switch (viewType)
			{
				case ViewType.SiteForm:
					return _siteFormViewModelFactory.CreateViewModel(viewModelBase, elem);
				case ViewType.DepartmentForm:
					return _departmentFormViewModelFactory.CreateViewModel(viewModelBase, elem);
				case ViewType.EmployeeForm:
					return _employeeFormViewModelFactory.CreateViewModel(viewModelBase, elem);
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
		}

		/*
		 * Creates Tab ViewModels
		 */
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

using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class EmployeeListViewModelFactory : IViewModelListFactory<EmployeeListViewModel>
	{
		private readonly IEmployeesService _employeeService;

		public EmployeeListViewModelFactory(IEmployeesService employeesService)
		{
			_employeeService = employeesService;
		}

		public EmployeeListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return EmployeeListViewModel.LoadEmployeeListViewModel(_employeeService, factory);
		}
	}
}

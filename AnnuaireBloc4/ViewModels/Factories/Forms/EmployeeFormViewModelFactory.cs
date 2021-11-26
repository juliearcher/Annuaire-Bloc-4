using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class EmployeeFormViewModelFactory : IViewModelFormFactory<EmployeeFormViewModel>
	{
		private readonly IEmployeesService _employeeService;
		private readonly ISitesService _sitesService;
		private readonly IDepartmentsService _departmentsService;

		public EmployeeFormViewModelFactory(IEmployeesService employeesService, ISitesService sitesService, IDepartmentsService departmentsService)
		{
			_employeeService = employeesService;
			_sitesService = sitesService;
			_departmentsService = departmentsService;
		}

		public EmployeeFormViewModel CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem)
		{
			return new EmployeeFormViewModel(_employeeService, _sitesService, _departmentsService, viewModelBase, (Employee)elem);
		}
	}
}

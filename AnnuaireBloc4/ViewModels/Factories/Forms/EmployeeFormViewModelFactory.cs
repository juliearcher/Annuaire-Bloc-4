using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AutoMapper;
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
		private IMapper _mapper;

		public EmployeeFormViewModelFactory(IEmployeesService employeesService, ISitesService sitesService, IDepartmentsService departmentsService, IMapper mapper)
		{
			_employeeService = employeesService;
			_sitesService = sitesService;
			_departmentsService = departmentsService;
			_mapper = mapper;
		}

		public EmployeeFormViewModel CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem)
		{
			return new EmployeeFormViewModel(_employeeService, _sitesService, _departmentsService, _mapper, viewModelBase, (Employee)elem);
		}
	}
}

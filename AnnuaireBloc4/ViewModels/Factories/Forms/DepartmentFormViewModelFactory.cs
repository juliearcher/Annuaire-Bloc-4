using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class DepartmentFormViewModelFactory : IViewModelFormFactory<DepartmentFormViewModel>
	{
		private readonly IDepartmentsService _departmentService;

		public DepartmentFormViewModelFactory(IDepartmentsService departmentsService)
		{
			_departmentService = departmentsService;
		}

		public DepartmentFormViewModel CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem)
		{
			return new DepartmentFormViewModel(_departmentService, viewModelBase, (Department)elem);
		}
	}
}

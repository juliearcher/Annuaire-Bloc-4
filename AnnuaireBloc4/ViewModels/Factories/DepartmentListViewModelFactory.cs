using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class DepartmentListViewModelFactory : IViewModelFactory<DepartmentListViewModel>
	{
		private readonly IDepartmentsService _departmentService;

		public DepartmentListViewModelFactory(IDepartmentsService departmentsService)
		{
			_departmentService = departmentsService;
		}

		public DepartmentListViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return DepartmentListViewModel.LoadDepartmentListViewModel(_departmentService, factory);
		}
	}
}

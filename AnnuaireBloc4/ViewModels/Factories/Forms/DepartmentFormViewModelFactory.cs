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
	public class DepartmentFormViewModelFactory : IViewModelFormFactory<DepartmentFormViewModel>
	{
		private readonly IDepartmentsService _departmentService;
		private IMapper _mapper;

		public DepartmentFormViewModelFactory(IDepartmentsService departmentsService, IMapper mapper)
		{
			_departmentService = departmentsService;
			_mapper = mapper;
		}

		public DepartmentFormViewModel CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem)
		{
			return new DepartmentFormViewModel(_departmentService, _mapper, viewModelBase, (Department)elem);
		}
	}
}

using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.Models;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class DepartmentFormViewModel : FormViewModelBase
	{
		private readonly IDepartmentsService _departmentsService;

		public DepartmentFormViewModel(IDepartmentsService departmentsService, IMapper mapper, ListViewModelBase listViewModelBase, Department department)
		{
			_departmentsService = departmentsService;
			_mapper = mapper;
			ListViewModelBase = listViewModelBase;
			_mode = department == null ? EditMode.CREATE : EditMode.UPDATE;
			NewElem = new DepartmentDataError(department ?? new Department());
		}

		public async override Task<bool> SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				Department newDep = await _departmentsService.CreateDepartment(_mapper.Map<Department>(NewElem));
				(NewElem as DepartmentDataError).Id = newDep.Id;
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _departmentsService.UpdateDepartment(_mapper.Map<Department>(NewElem));
			}
			return true;
		}

		public override bool IsValid()
		{
			return NewElem.CanCreate;
		}
	}
}

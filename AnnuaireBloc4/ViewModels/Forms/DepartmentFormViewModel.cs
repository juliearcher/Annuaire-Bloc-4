using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class DepartmentFormViewModel : FormViewModelBase
	{
		private readonly IDepartmentsService _departmentsService;
		private Department _department;
		public Department Department
		{
			get
			{
				return _department;
			}
			set
			{
				_department = value;
				OnPropertyChanged(nameof(Department));
			}
		}

		public DepartmentFormViewModel(IDepartmentsService departmentsService, ListViewModelBase listViewModelBase, Department department)
		{
			_departmentsService = departmentsService;
			ListViewModelBase = listViewModelBase;
			_mode = department == null ? EditMode.CREATE : EditMode.UPDATE;
			Department = department ?? new Department();
		}

		public async override Task<bool> SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				await _departmentsService.CreateDepartment(Department);
			}
			else
			{
				await _departmentsService.UpdateDepartment(Department);
			}
			return true;
		}

		public override bool IsValid()
		{
			// TODO
			return true;
		}

	}
}

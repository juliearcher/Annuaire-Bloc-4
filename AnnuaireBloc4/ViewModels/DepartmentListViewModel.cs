using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.Models;
using AnnuaireBloc4.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class DepartmentListViewModel : ViewModelBase
	{

		private readonly IDepartmentsService _departmentsService;

		private IEnumerable<Department> _departmentList;
		public IEnumerable<Department> DepartmentList
		{
			get
			{
				return _departmentList;
			}
			set
			{
				_departmentList = value;
				OnPropertyChanged(nameof(DepartmentList));
			}
		}

		public DepartmentListViewModel(IDepartmentsService departmentsService)
		{
			_departmentsService = departmentsService;
			DepartmentList = new ObservableCollection<Department>();
		}

		public static DepartmentListViewModel LoadDepartmentListViewModel(IDepartmentsService departmentsServices)
		{
			DepartmentListViewModel departmentsListViewModel = new DepartmentListViewModel(departmentsServices);
			departmentsListViewModel.LoadDepartments();
			return departmentsListViewModel;
		}

		private void LoadDepartments()
		{
			_departmentsService.GetAllDepartments().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					DepartmentList = task.Result;
				}
			});
		}
	}
}


using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.Models;
using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AnnuaireBloc4.ViewModels
{
	public class DepartmentListViewModel : ListViewModelBase
	{
		private readonly IDepartmentsService _departmentsService;


		private IEnumerable<Department> _departmentInitialList;
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
		private string _searchFilter;
		public string SearchFilter
		{
			get
			{
				return _searchFilter;
			}
			set
			{
				if (_searchFilter != value)
				{
					_searchFilter = value.ToLower();
					DepartmentList = _departmentInitialList.Where(d => d.Name.ToLower().Contains(_searchFilter ?? ""));
					OnPropertyChanged(nameof(SearchFilter));
				}
			}
		}

		public DepartmentListViewModel(IDepartmentsService departmentsService, IViewModelAbstractFactory viewModelFactory)
		{
			_departmentsService = departmentsService;
			_departmentInitialList = new ObservableCollection<Department>();
			ViewModelFactory = viewModelFactory;
		}

		public static DepartmentListViewModel LoadDepartmentListViewModel(IDepartmentsService departmentsServices, IViewModelAbstractFactory viewModelFactory)
		{
			DepartmentListViewModel departmentsListViewModel = new DepartmentListViewModel(departmentsServices, viewModelFactory);
			departmentsListViewModel.LoadDepartments();
			return departmentsListViewModel;
		}

		private void LoadDepartments()
		{
			_departmentsService.GetAllDepartments().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					_departmentInitialList = task.Result;
					DepartmentList = _departmentInitialList.Where(d => d.Name.ToLower().Contains(_searchFilter ?? ""));
				}
			});
		}

		override public void LoadList()
		{
			this.LoadDepartments();
		}

		override public async Task<bool> DeleteSelectedItem()
		{
			return await _departmentsService.DeleteDepartment(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}


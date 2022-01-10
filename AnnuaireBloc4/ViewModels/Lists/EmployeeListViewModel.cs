using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public class EmployeeListViewModel : ListViewModelBase
	{
		private readonly IEmployeesService _employeesService;

		private IEnumerable<Employee> _employeeInitialList;
		private IEnumerable<Employee> _employeeList;
		public IEnumerable<Employee> EmployeeList
		{
			get
			{
				return _employeeList;
			}
			set
			{
				_employeeList = value;
				OnPropertyChanged(nameof(EmployeeList));
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
					EmployeeList = _employeeInitialList.Where(d => d.Name.ToLower().Contains(_searchFilter) || d.Surname.ToLower().Contains(_searchFilter));
					OnPropertyChanged(nameof(SearchFilter));
				}
			}
		}


		public EmployeeListViewModel(IEmployeesService employeesService, IViewModelAbstractFactory viewModelFactory)
		{
			_employeesService = employeesService;
			_employeeInitialList = new ObservableCollection<Employee>();
			ViewModelFactory = viewModelFactory;
		}

		public static EmployeeListViewModel LoadEmployeeListViewModel(IEmployeesService employeesServices, IViewModelAbstractFactory viewModelFactory)
		{
			EmployeeListViewModel employeesListViewModel = new EmployeeListViewModel(employeesServices, viewModelFactory);
			employeesListViewModel.LoadEmployees();
			return employeesListViewModel;
		}

		private void LoadEmployees()
		{
			_employeesService.GetAllEmployees().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					_employeeInitialList = task.Result.OrderBy(employee => employee.Surname + " " + employee.Name);
					EmployeeList = _employeeInitialList;
				}
			});
		}

		override public void LoadList()
		{
			this.LoadEmployees();
		}

		override public async Task<bool> DeleteSelectedItem()
		{
			return await _employeesService.DeleteEmployee(SelectedItem == null ? 0 : SelectedItem.Id);
		}
	}
}

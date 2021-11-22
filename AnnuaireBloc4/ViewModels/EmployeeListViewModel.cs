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

		public EmployeeListViewModel(IEmployeesService employeesService, IViewModelAbstractFactory viewModelFactory)
		{
			_employeesService = employeesService;
			EmployeeList = new ObservableCollection<Employee>();
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
					EmployeeList = task.Result;
				}
			});
		}
	}
}

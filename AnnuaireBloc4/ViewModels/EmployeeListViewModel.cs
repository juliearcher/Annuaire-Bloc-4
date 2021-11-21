﻿using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using AnnuaireBloc4.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class EmployeeListViewModel : ViewModelBase
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

		public EmployeeListViewModel(IEmployeesService employeesService)
		{
			_employeesService = employeesService;
			EmployeeList = new ObservableCollection<Employee>();
		}

		public static EmployeeListViewModel LoadEmployeeListViewModel(IEmployeesService employeesServices)
		{
			EmployeeListViewModel employeesListViewModel = new EmployeeListViewModel(employeesServices);
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
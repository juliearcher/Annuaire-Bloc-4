using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class EmployeeFormViewModel : FormViewModelBase
	{
		private readonly IEmployeesService _employeesService;
		private readonly ISitesService _sitesService;
		private readonly IDepartmentsService _departmentsService;
		private IEnumerable<Site> _siteList;
		public IEnumerable<Site> SiteList
		{
			get
			{
				return _siteList;
			}
			set
			{
				if (value != null)
				{
					_siteList = value;
					OnPropertyChanged(nameof(SiteList));
				}
			}
		}
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

		private Employee _employee;
		public Employee Employee
		{
			get
			{
				return _employee;
			}
			set
			{
				_employee = value;
				OnPropertyChanged(nameof(Employee));
			}
		}
		private Site _selectedSite;
		public Site SelectedSite
		{
			get
			{
				return _selectedSite;
			}
			set
			{
				_selectedSite = value;
				Employee.SitesId = _selectedSite.Id;
				OnPropertyChanged(nameof(SelectedSite));
			}
		}

		private Department _selectedDepartment;
		public Department SelectedDepartment
		{
			get
			{
				return _selectedDepartment;
			}
			set
			{
				_selectedDepartment = value;
				Employee.DepartmentsId = _selectedDepartment.Id;
				OnPropertyChanged(nameof(SelectedDepartment));
			}
		}

		public EmployeeFormViewModel(IEmployeesService employeesService, ISitesService sitesService, IDepartmentsService departmentsService, ListViewModelBase listViewModelBase, Employee employee)
		{
			_employeesService = employeesService;
			_sitesService = sitesService;
			_departmentsService = departmentsService;
			ListViewModelBase = listViewModelBase;
			_mode = employee == null ? EditMode.CREATE : EditMode.UPDATE;
			Employee = employee ?? new Employee();
			LoadSites();
			LoadDepartments();
		}

		private void LoadSites()
		{
			_sitesService.GetAllSites().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					SiteList = task.Result;
					if (Employee != null && Employee.SitesId != 0)
						SelectedSite = SiteList.FirstOrDefault(site => site.Id == Employee.SitesId);
				}
			});
		}
		private void LoadDepartments()
		{
			_departmentsService.GetAllDepartments().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					DepartmentList = task.Result;
					if (Employee != null && Employee.DepartmentsId != 0)
						SelectedDepartment = DepartmentList.FirstOrDefault(department => department.Id == Employee.DepartmentsId);
				}
			});
		}

		public async override Task<bool> SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				await _employeesService.CreateEmployee(Employee);
			}
			else
			{
				await _employeesService.UpdateEmployee(Employee);
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

using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.Commands
{
	public class UpdateCurrentViewModelCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private INavigator _navigator;

		public UpdateCurrentViewModelCommand(INavigator navigator)
		{
			_navigator = navigator;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (parameter is ViewType)
			{
				ViewType viewType = (ViewType)parameter;
				switch (viewType)
				{
					case ViewType.Home:
						_navigator.CurrentViewModel = new HomeViewModel(SiteListViewModel.LoadSiteListViewModel(new SitesService()), DepartmentListViewModel.LoadDepartmentListViewModel(new DepartmentsService()));
						break;
					case ViewType.Sites:
						_navigator.CurrentViewModel = new SitesViewModel(SiteListViewModel.LoadSiteListViewModel(new SitesService()));
						break;
					case ViewType.Departments:
						_navigator.CurrentViewModel = new DepartmentsViewModel(DepartmentListViewModel.LoadDepartmentListViewModel(new DepartmentsService()));
						break;
					case ViewType.Employees:
						_navigator.CurrentViewModel = new EmployeesViewModel(EmployeeListViewModel.LoadEmployeeListViewModel(new EmployeesService()));
						break;
					default:
						break;
				}
			}
		}
	}
}

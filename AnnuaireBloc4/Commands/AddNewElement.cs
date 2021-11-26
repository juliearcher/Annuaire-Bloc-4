using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.ViewModels;
using AnnuaireBloc4.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnnuaireBloc4.Commands
{
	class AddNewElement : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private ListViewModelBase _viewModel;

		public AddNewElement(ListViewModelBase viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			Window window = new Window();
			if (_viewModel is SiteListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.SiteForm, null);
			else if (_viewModel is DepartmentListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.DepartmentForm, null);
			else if (_viewModel is EmployeeListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.EmployeeForm, null);
			else
				return;
			window.Show();
		}
	}
}

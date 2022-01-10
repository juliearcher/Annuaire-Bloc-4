using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnnuaireBloc4.Commands
{
	class UpdateElement : ICommand
	{
		private ListViewModelBase _viewModel;

		public event EventHandler CanExecuteChanged;

		public UpdateElement(ListViewModelBase viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (_viewModel.SelectedItem == null)
				return;
			Window window = new Window();
			if (_viewModel is SiteListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.SiteForm, _viewModel.SelectedItem);
			else if (_viewModel is DepartmentListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.DepartmentForm, _viewModel.SelectedItem);
			else if (_viewModel is EmployeeListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.EmployeeForm, _viewModel.SelectedItem);
			else
				return;
			window.Show();
		}
	}
}

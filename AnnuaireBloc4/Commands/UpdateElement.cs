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
			Window window = new Window();
			window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(ViewType.SiteForm, _viewModel.SelectedItem);
			window.Show();
		}
	}
}

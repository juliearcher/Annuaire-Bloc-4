using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.Commands
{
	class SaveElement : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private FormViewModelBase _viewModel;
		private bool _closeWindow;

		public SaveElement(FormViewModelBase viewModel, bool closeWindow = false)
		{
			_viewModel = viewModel;
			_closeWindow = closeWindow;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_viewModel.SendToAPI(_closeWindow);
		}
	}
}

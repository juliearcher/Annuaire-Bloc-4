using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

		public async void Execute(object parameter)
		{
			// TODO CHECK API RESULT CODE
			if (!_viewModel.IsValid())
			{
				return;
			}
			try
			{
				await _viewModel.SendToAPI();
				if (parameter is Window && _closeWindow)
					_viewModel.CloseWindow((Window)parameter);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}

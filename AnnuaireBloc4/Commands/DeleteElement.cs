using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.Commands
{
	class DeleteElement : ICommand
	{
		private ListViewModelBase _viewModel;

		public event EventHandler CanExecuteChanged;

		public DeleteElement(ListViewModelBase viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			// TODO ADD NEW ELEMENT
		}
	}
}

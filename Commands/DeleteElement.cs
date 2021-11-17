﻿using Annuaire_Bloc_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.Commands
{
	class DeleteElement : ICommand
	{
		private IListViewModel _viewModel;

		public event EventHandler CanExecuteChanged;

		public DeleteElement(IListViewModel viewModel)
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

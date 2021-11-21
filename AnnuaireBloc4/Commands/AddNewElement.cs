﻿using AnnuaireBloc4.ViewModels;
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

		private IListViewModel _viewModel;

		public AddNewElement(IListViewModel viewModel)
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
			window.Show();
			// TODO ADD NEW ELEMENT
		}
	}
}

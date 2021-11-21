using AnnuaireBloc4.PrepAPI.Services;
using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.ViewModels;
using AnnuaireBloc4.ViewModels.Factories;
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
		private readonly IViewModelAbstractFactory _viewModelFactory;

		public UpdateCurrentViewModelCommand(INavigator navigator, IViewModelAbstractFactory viewModelFactory)
		{
			_navigator = navigator;
			_viewModelFactory = viewModelFactory;
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
				_navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
			}
		}
	}
}

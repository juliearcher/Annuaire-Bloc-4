using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Models;
using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.State.Navigators
{
	public class Navigator : ObservableObject, INavigator
	{
		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
			set
			{
				_currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}

		public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

	}
}

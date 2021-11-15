using Annuaire_Bloc_4.Commands;
using Annuaire_Bloc_4.Models;
using Annuaire_Bloc_4.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.State.Navigators
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

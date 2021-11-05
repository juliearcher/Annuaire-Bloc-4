using Annuaire_Bloc_4.Command;
using Annuaire_Bloc_4.Model;
using Annuaire_Bloc_4.ViewModel;
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

using Annuaire_Bloc_4.Command;
using Annuaire_Bloc_4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.State.Navigators
{
	public class Navigator : INavigator
	{
		public ViewModelBase CurrentViewModel { get; set; }

		public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
	}
}

using Annuaire_Bloc_4.State.Navigators;
using Annuaire_Bloc_4.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.Commands
{
	public class UpdateCurrentViewModelCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private INavigator _navigator;

		public UpdateCurrentViewModelCommand(INavigator navigator)
		{
			_navigator = navigator;
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
				switch (viewType)
				{
					case ViewType.Home:
						_navigator.CurrentViewModel = new HomeViewModel();
						break;
					case ViewType.Sites:
						_navigator.CurrentViewModel = new SitesViewModel();
						break;
					default:
						break;
				}
			}
		}
	}
}

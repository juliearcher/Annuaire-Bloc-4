using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.State.NewWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public INavigator Navigator { get; set; }

		public MainWindowViewModel(INavigator navigator)
		{
			Navigator = navigator;
			Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
		}
	}
}

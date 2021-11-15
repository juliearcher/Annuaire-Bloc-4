﻿using Annuaire_Bloc_4.State.Navigators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public INavigator Navigator { get; set; } = new Navigator();

		public MainWindowViewModel()
		{
			Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
		}
	}
}

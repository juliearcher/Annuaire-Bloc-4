using AnnuaireBloc4.State.Navigators;
using AnnuaireBloc4.ViewModels.Factories;
using AnnuaireBloc4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		/*
		 * Navigation bar, used to change the current viewmodel
		 */
		public INavigator Navigator { get; set; }
		public static AdministratorDependency Administrator { get; set; }
		public ICommand ChangeAdminStatus => new AdministratorCommand();

		public MainWindowViewModel(INavigator navigator)
		{
			Navigator = navigator;
			Administrator = new AdministratorDependency();
			Administrator.Administrator = false;
			Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
		}

		internal class AdministratorCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter)
			{
				return !Administrator.Administrator;
			}

			public void Execute(object parameter)
			{
				Window window = new Window();
				window.Content = new AdminPasswordWindowViewModel();
				window.Height = 120;
				window.Width = 300;
				window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
				window.ShowDialog();
			}
		}

		/*
		 * Allows to use a changing static property in bindings
		 */
		public class AdministratorDependency : DependencyObject
		{
			public static readonly DependencyProperty AdministratorProperty =
				DependencyProperty.Register("Administrator", typeof(bool),
				typeof(AdministratorDependency));
			public bool Administrator
			{
				get { return (bool)GetValue(AdministratorProperty); }
				set { SetValue(AdministratorProperty, value); }
			}
		}
	}
}

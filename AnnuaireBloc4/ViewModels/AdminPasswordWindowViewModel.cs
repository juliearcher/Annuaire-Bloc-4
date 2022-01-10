using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public class AdminPasswordWindowViewModel : ViewModelBase
	{
		private	string _password = "Cesi"; // A SECURISER
		public ICommand CloseWindow => new CloseWindowCommand();
		public ICommand CheckAdminPassword => new CheckPasswordCommand(this);
		public string PasswordGuess { private get; set; }
		private string _errorMessage;
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
				OnPropertyChanged(nameof(ErrorMessage));
			}
		}

		public bool IsPasswordValid()
		{
			return _password == PasswordGuess;
		}

		internal class CloseWindowCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				if (parameter is Window)
					((Window)parameter).Close();
			}
		}

		internal class CheckPasswordCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;

			AdminPasswordWindowViewModel _viewmodel;

			public CheckPasswordCommand(AdminPasswordWindowViewModel viewmodel)
			{
				_viewmodel = viewmodel;
			}

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				if (_viewmodel.IsPasswordValid())
				{
					MainWindowViewModel.Administrator.Administrator = true;
					if (parameter is Window)
						((Window)parameter).Close();
				}
				else
				{
					_viewmodel.ErrorMessage = "Mot de passe invalide";
				}
			}
		}
	}
}

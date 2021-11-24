using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public abstract class FormViewModelBase : ViewModelBase
	{
		protected enum EditMode
		{
			CREATE, UPDATE
		}

		protected EditMode _mode = EditMode.UPDATE;

		public abstract Task<bool> SendToAPI();
		public abstract bool IsValid();
		public ICommand SaveElement => new SaveElement(this, false);
		public ICommand SaveElementAndClose => new SaveElement(this, true);
		public void CloseWindow(Window window) => window.Close();
	}
}

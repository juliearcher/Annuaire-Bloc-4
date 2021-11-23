using AnnuaireBloc4.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public abstract class FormViewModelBase : ViewModelBase
	{
		public abstract void SendToAPI(bool close);
		public ICommand SaveElement => new SaveElement(this, false);
	}
}

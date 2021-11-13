using Annuaire_Bloc_4.State.Navigators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.ViewsModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public INavigator Navigator { get; set; } = new Navigator();
	}
}

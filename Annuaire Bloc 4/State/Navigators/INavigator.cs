using Annuaire_Bloc_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.State.Navigators
{
	public enum ViewType
	{
		Home,
		Sites,
		Departments,
		Employees
	};

	public interface INavigator
	{
		ViewModelBase CurrentViewModel { get; set; }
		ICommand UpdateCurrentViewModelCommand { get; }

	}
}

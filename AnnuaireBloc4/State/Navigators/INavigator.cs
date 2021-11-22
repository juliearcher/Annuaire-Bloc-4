using AnnuaireBloc4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.State.Navigators
{
	public enum ViewType
	{
		Home,
		Sites,
		Departments,
		Employees,
		SiteForm
	};

	public interface INavigator
	{
		ViewModelBase CurrentViewModel { get; set; }
		ICommand UpdateCurrentViewModelCommand { get; }

	}
}

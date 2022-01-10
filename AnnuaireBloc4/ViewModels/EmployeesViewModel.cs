using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class EmployeesViewModel : ViewModelBase
	{
		public EmployeeListViewModel EmployeeListViewModel { get; set; }

		public EmployeesViewModel(EmployeeListViewModel employeesListViewModel)
		{
			EmployeeListViewModel = employeesListViewModel;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class EmployeesViewModelFactory : IViewModelFactory<EmployeesViewModel>
	{
		private IViewModelFactory<EmployeeListViewModel> _employeeListViewModelFactory;

		public EmployeesViewModelFactory(IViewModelFactory<EmployeeListViewModel> employeeListViewModelFactory)
		{
			_employeeListViewModelFactory = employeeListViewModelFactory;
		}

		public EmployeesViewModel CreateViewModel()
		{
			return new EmployeesViewModel(_employeeListViewModelFactory.CreateViewModel());
		}
	}
}

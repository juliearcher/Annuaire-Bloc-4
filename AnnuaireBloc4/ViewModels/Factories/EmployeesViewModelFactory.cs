using AnnuaireBloc4.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class EmployeesViewModelFactory : IViewModelListFactory<EmployeesViewModel>
	{
		private IViewModelListFactory<EmployeeListViewModel> _employeeListViewModelFactory;

		public EmployeesViewModelFactory(IViewModelListFactory<EmployeeListViewModel> employeeListViewModelFactory)
		{
			_employeeListViewModelFactory = employeeListViewModelFactory;
		}

		public EmployeesViewModel CreateViewModel(IViewModelAbstractFactory factory)
		{
			return new EmployeesViewModel(_employeeListViewModelFactory.CreateViewModel(factory));
		}
	}
}

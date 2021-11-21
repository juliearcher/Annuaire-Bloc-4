using AnnuaireBloc4.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public class ViewModelAbstractFactory : IViewModelAbstractFactory
	{
		private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
		private readonly IViewModelFactory<EmployeesViewModel> _employeesViewModelFactory;

		public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory, IViewModelFactory<EmployeesViewModel> employeesViewModelFactory)
		{
			_homeViewModelFactory = homeViewModelFactory;
			_employeesViewModelFactory = employeesViewModelFactory;
		}

		public ViewModelBase CreateViewModel(ViewType viewType)
		{
			switch (viewType)
			{
				case ViewType.Home:
					return _homeViewModelFactory.CreateViewModel();
				case ViewType.Employees:
					return _employeesViewModelFactory.CreateViewModel();
				default:
					throw new ArgumentException("Invalid ViewType : .", "viewType");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels
{
	public class DepartmentsViewModel : ViewModelBase
	{
		public DepartmentListViewModel DepartmentListViewModel { get; set; }

		public DepartmentsViewModel(DepartmentListViewModel departmentListViewModel)
		{
			DepartmentListViewModel = departmentListViewModel;
		}
	}
}

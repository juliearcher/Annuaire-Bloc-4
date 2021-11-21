using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public interface IViewModelFactory<T> where T : ViewModelBase
	{
		T CreateViewModel();
	}
}

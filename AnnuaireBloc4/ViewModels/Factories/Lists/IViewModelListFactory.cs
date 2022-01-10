using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public interface IViewModelListFactory<T> where T : ViewModelBase
	{
		T CreateViewModel(IViewModelAbstractFactory factory);
	}
}

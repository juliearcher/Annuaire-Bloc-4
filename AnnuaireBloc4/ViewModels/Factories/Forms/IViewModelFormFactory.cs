using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public interface IViewModelFormFactory<T> where T : ViewModelBase
	{
		T CreateViewModel(ListViewModelBase viewModelBase, IApiModel elem);
	}
}

using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.ViewModels.Factories
{
	public interface IViewModelAbstractFactory
	{
		ViewModelBase CreateViewModel(ViewType viewType);
		ViewModelBase CreateFormViewModel(ViewType viewType, IApiModel elem);
	}
}

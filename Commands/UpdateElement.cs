using Annuaire_Bloc_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Commands
{
	class UpdateElement
	{
		private IListViewModel _viewModel;

		public UpdateElement(IListViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			// TODO UPDATE ELEMENT
		}
	}
}

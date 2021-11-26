using AnnuaireBloc4.Commands;
using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public abstract class ListViewModelBase :ViewModelBase
	{
		public IApiModel SelectedItem { get; set; }
		public IViewModelAbstractFactory ViewModelFactory { get; protected set; }

		public ICommand AddNewElement => new AddNewElement(this);

		public ICommand UpdateElement => new UpdateElement(this);

		public ICommand DeleteElement => new DeleteElement(this);

		public abstract void LoadList();

		public abstract Task<bool> DeleteSelectedItem();
	}
}

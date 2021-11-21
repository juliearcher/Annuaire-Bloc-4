using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnnuaireBloc4.ViewModels
{
	public interface IListViewModel
	{
		public IApiModel SelectedItem { get; set; }
		public ICommand AddNewElement { get; }
		public ICommand UpdateElement { get; }
		public ICommand DeleteElement { get; }
	}
}

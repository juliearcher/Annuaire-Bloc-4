using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Annuaire_Bloc_4.ViewModels
{
	public interface IListViewModel
	{
		public object SelectedItem { get; set; }
		public ICommand AddNewElement { get; }
		public ICommand UpdateElement { get; }
		public ICommand DeleteElement { get; }
	}
}

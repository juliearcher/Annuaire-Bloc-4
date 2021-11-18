using Annuaire_Bloc_4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.ViewModels
{
	public class SiteFormViewModel : ViewModelBase
	{
		public Site Site { get; }

		public SiteFormViewModel(Site site)
		{
			Site = site;
		}
	}
}

using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Models
{
	public class SiteDataError : DataErrorModel, ISite
	{
		public long Id { get; set; }
		private string _city;
		public string City
		{
			get
			{
				return _city;
			}
			set
			{
				_city = value;
				ClearErrors(nameof(City));
				if (_city == null || _city?.Trim().Length == 0)
				{
					AddError(nameof(City), "Champ obligatoire");
				}
				OnPropertyChanged(nameof(City));
			}
		}

		public SiteDataError(Site site)
		{
			if (site != null)
			{
				Id = site.Id;
				City = site.City;
			}
		}
	}
}

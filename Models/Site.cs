using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Models
{
	public class Site : IApiModel
	{
		public long Id { get; set; }
		public string City { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Models
{
	public interface ISite : IApiModel
	{
		public string City { get; set; }
	}
}

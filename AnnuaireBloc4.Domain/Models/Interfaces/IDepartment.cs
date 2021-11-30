using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Models
{
	public interface IDepartment : IApiModel
	{
		public string Name { get; set; }
	}
}

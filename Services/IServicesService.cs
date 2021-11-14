using Annuaire_Bloc_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Services
{
	public interface IServicesService
	{
		Task<IEnumerable<Service>> GetAllServices();
		Task<Service> GetServiceById(int id);
	}
}

using Annuaire_Bloc_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Services
{
	public interface IDepartmentsService
	{
		Task<IEnumerable<Department>> GetAllDepartments();
		Task<Department> GetDepartmentById(int id);
	}
}

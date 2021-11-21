using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Services
{
	public interface IEmployeesService
	{
		Task<IEnumerable<Employee>> GetAllEmployees();
		Task<Employee> GetEmployeeById(int id);
	}
}

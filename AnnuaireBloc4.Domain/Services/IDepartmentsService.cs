using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Services
{
	public interface IDepartmentsService
	{
		Task<IEnumerable<Department>> GetAllDepartments();
		Task<Department> GetDepartmentById(int id);
		Task<Department> CreateDepartment(Department department);
	}
}

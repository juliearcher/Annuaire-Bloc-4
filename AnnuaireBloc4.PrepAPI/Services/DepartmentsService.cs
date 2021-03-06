using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.PrepAPI.Services
{
	public class DepartmentsService : IDepartmentsService
	{
		public async Task<IEnumerable<Department>> GetAllDepartments()
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				IEnumerable<Department> departmentList = await client.GetAsync<IEnumerable<Department>>("departments");
				return departmentList;
			}
		}

		public async Task<Department> GetDepartmentById(int id)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var department = await client.GetAsync<Department>("departments/" + id);
				return department;
			}
		}

		public async Task<Department> CreateDepartment(Department department)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var response = await client.PostAsync<Department, Department>("departments/", department);
				return response;
			}
		}

		public async Task<bool> UpdateDepartment(Department department)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				int response = await client.PutAsync<Department, int>("departments/" + department.Id, department);
				return response == 200;
			}
		}

		public async Task<bool> DeleteDepartment(long id)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				int response = await client.CustomDeleteAsync("departments/" + id);
				return response == 200;
			}
		}
	}
}

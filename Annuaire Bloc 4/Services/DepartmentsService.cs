using Annuaire_Bloc_4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Services
{
	public class DepartmentsService : IDepartmentsService
	{
		public async Task<IEnumerable<Department>> GetAllDepartments()
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/departments");
				string jsonResponse = await response.Content.ReadAsStringAsync();

				IEnumerable<Department> departmentList = JsonConvert.DeserializeObject<IEnumerable<Department>>(jsonResponse);
				return departmentList;
			}
		}

		public async Task<Department> GetDepartmentById(int id)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/departments/" + id);
				string jsonResponse = await response.Content.ReadAsStringAsync();

				Department department = JsonConvert.DeserializeObject<Department>(jsonResponse);
				return department;
			}
		}
	}
}

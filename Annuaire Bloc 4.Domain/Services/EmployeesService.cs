using Annuaire_Bloc_4.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Domain.Services
{
	public class EmployeesService : IEmployeesService
	{
		public async Task<IEnumerable<Employee>> GetAllEmployees()
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/employees");
				string jsonResponse = await response.Content.ReadAsStringAsync();

				IEnumerable<Employee> employeeList = JsonConvert.DeserializeObject<IEnumerable<Employee>>(jsonResponse);
				return employeeList;
			}
		}

		public async Task<Employee> GetEmployeeById(int id)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/employees/" + id);
				string jsonResponse = await response.Content.ReadAsStringAsync();

				Employee employee = JsonConvert.DeserializeObject<Employee>(jsonResponse);
				return employee;
			}
		}
	}
}

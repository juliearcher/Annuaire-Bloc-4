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
	public class EmployeesService : IEmployeesService
	{
		public async Task<IEnumerable<Employee>> GetAllEmployees()
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var employeeList = await client.GetAsync<IEnumerable<Employee>>("employees");
				return employeeList;
			}
		}

		public async Task<Employee> GetEmployeeById(int id)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var employee = await client.GetAsync<Employee>("employees/" + id);
				return employee;
			}
		}

		public async Task<Employee> CreateEmployee(Employee employee)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				var response = await client.PostAsync<Employee, Employee>("employees/", employee);
				return response;
			}
		}

		public async Task<bool> UpdateEmployee(Employee employee)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				int response = await client.PutAsync<Employee, int>("employees/" + employee.Id, employee);
				return response == 200;
			}
		}

		public async Task<bool> DeleteEmployee(long id)
		{
			using (AnnuaireHttpClient client = new AnnuaireHttpClient())
			{
				int response = await client.CustomDeleteAsync("employees/" + id);
				return response == 200;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Models
{
	public sealed class Employee
	{
		public Employee(string name, string surname, string phone, string mobile, string mail)
		{
			Name = name;
			Surname = surname;
			Phone = phone;
			Mobile = mobile;
			Mail = mail;

		}

		public int Id { get; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Mail { get; set; }

	}
}

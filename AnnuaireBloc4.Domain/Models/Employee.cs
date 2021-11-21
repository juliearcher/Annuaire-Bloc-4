﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Models
{
	public sealed class Employee : IApiModel
	{
		public Employee(string name, string surname, string phone, string mobile, string mail)
		{
			Name = name;
			Surname = surname;
			Phone = phone;
			Mobile = mobile;
			Mail = mail;
		}

		public long Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Mail { get; set; }
		public string Site { get; set; }
		public string Department { get; set; }

	}
}
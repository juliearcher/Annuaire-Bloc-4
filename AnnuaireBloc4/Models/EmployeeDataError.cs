using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Models
{
	public class EmployeeDataError : DataErrorModel, IEmployee
	{
		Regex phoneRegex = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				ClearErrors(nameof(Name));
				if (_name == null || _name?.Trim().Length == 0)
				{
					AddError(nameof(Name), "Champ obligatoire");
				}
				OnPropertyChanged(nameof(Name));
			}
		}

		private string _surname;
		public string Surname
		{
			get
			{
				return _surname;
			}
			set
			{
				_surname = value;
				ClearErrors(nameof(Surname));
				if (_surname == null || _surname?.Trim().Length == 0)
				{
					AddError(nameof(Surname), "Champ obligatoire");
				}
				OnPropertyChanged(nameof(Surname));
			}
		}

		private string _phone;
		public string Phone
		{
			get
			{
				return _phone;
			}
			set
			{
				_phone = value;
				ClearErrors(nameof(Phone));
				if (_phone != null && !phoneRegex.IsMatch(_phone))
				{
					AddError(nameof(Phone), "Numéro de téléphone invalide");
				}
				OnPropertyChanged(nameof(Phone));
			}
		}

		private string _mobile;
		public string Mobile
		{
			get
			{
				return _mobile;
			}
			set
			{
				_mobile = value;
				ClearErrors(nameof(Mobile));
				if (_mobile != null && !phoneRegex.IsMatch(_mobile))
				{
					AddError(nameof(Mobile), "Numéro de téléphone invalide");
				}
				OnPropertyChanged(nameof(Mobile));
			}
		}

		private string _mail;
		public string Mail
		{
			get
			{
				return _mail;
			}
			set
			{
				_mail = value;
				ClearErrors(nameof(Mail));
				if (_mail != null && _mail?.Trim().Length != 0)
				{
					try
					{
						MailAddress address = new MailAddress(_mail);
						if (address.Address != _mail)
							AddError(nameof(Mail), "Adresse email invalide");
					}
					catch (FormatException)
					{
						AddError(nameof(Mail), "Adresse email invalide");
					}
				}
				OnPropertyChanged(nameof(Mail));
			}
		}

		public string Site { get; set; }
		public string Department { get; set; }

		public long DepartmentsId { get; set; }
		public long SitesId { get; set; }
		public long Id { get; set; }

		public EmployeeDataError(Employee employee)
		{
			if (employee != null)
			{
				Name = employee.Name;
				Surname = employee.Surname;
				Phone = employee.Phone;
				Mobile = employee.Mobile;
				Mail = employee.Mail;
				Site = employee.Site;
				Department = employee.Department;
				DepartmentsId = employee.DepartmentsId;
				SitesId = employee.SitesId;
				Id = employee.Id;
			}
		}
	}
}

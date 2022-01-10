using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Models
{
	public class DepartmentDataError : DataErrorModel, IDepartment
	{
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

		public long Id { get; set; }

		public DepartmentDataError(Department department)
		{
			if (department != null)
			{
				Name = department.Name;
				Id = department.Id;
			}
		}
	}
}

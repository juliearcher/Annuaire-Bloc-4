using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnnuaireBloc4.ValidationRules
{
	class EmptyFieldValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			return new ValidationResult(value != null && value.ToString().Length > 0, "Mandatory field");
		}
	}
}

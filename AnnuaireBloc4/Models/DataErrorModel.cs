using AnnuaireBloc4.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Models
{
	/*
	 * Implement INotifyDataErrorInfo wich will allow the view to change if there are errors
	 */
	public class DataErrorModel : ObservableObject, INotifyDataErrorInfo
	{
		protected readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		public bool CanCreate => !HasErrors;
		public bool HasErrors => _propertyErrors.Any();
		public IEnumerable GetErrors(string propertyName)
		{
			return _propertyErrors.GetValueOrDefault(propertyName, null);
		}

		public void AddError(string propertyName, string errorMessage)
		{
			if (!_propertyErrors.ContainsKey(propertyName))
			{
				_propertyErrors.Add(propertyName, new List<string>());
			}
			_propertyErrors[propertyName].Add(errorMessage);
			OnErrorsChanged(propertyName);
		}
		public void ClearErrors(string propertyName)
		{
			if (_propertyErrors.Remove(propertyName))
				OnErrorsChanged(propertyName);
		}
		private void OnErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			OnPropertyChanged(nameof(CanCreate));
		}
	}
}

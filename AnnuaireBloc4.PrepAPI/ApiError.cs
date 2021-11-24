using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.PrepAPI
{
	public class ApiError
	{
		public object Errors { get; set; }

		public string Title { get; set; }

		public class ApiErrorMessage
		{
			public string[] Name { get; set; }

			public ApiErrorMessage(string name)
			{
				Name = new string[] { name };
			}
		}

		public ApiError(string title, string errorMessage)
		{
			Title = title;
			Errors = new ApiErrorMessage(errorMessage);
		}
	}
}

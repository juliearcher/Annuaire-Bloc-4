using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain
{
	public class ApiException : Exception
    {
        public string Title { get; set; }

        public ApiException()
        {
        }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, Exception inner)
            : base(message, inner)
        {
        }
        public ApiException(string title, string message)
           : base(message)
        {
            Title = title;
        }
    }
}

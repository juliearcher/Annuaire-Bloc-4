﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Domain.Models
{
	public class Site : ISite
	{
		public long Id { get; set; }
		public string City { get; set; }
	}
}

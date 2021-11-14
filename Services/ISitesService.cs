﻿using Annuaire_Bloc_4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_Bloc_4.Services
{
	public interface ISitesService
	{
		Task<ObservableCollection<Site>> GetAllSites();
		Task<Site> GetSiteById(int id);
	}
}

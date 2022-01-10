using AnnuaireBloc4.Domain.Models;
using AnnuaireBloc4.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuaireBloc4.Profiles
{
	public class DataErrorProfile : Profile
	{
		public DataErrorProfile()
		{
			CreateMap<SiteDataError, Site>();
			CreateMap<DepartmentDataError, Department>();
			CreateMap<EmployeeDataError, Employee>();
		}
	}
}

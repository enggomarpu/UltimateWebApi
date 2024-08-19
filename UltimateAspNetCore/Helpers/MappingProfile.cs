using AutoMapper;
using Entities.Modals;
using Shared.DTOs;

namespace UltimateAspNetCore.Helpers
{
	public class MappingProfile : Profile 
	{
		public MappingProfile()
		{
			CreateMap<Company, CompanyDto>()
.ForCtorParam("FullAddress",
opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
			CreateMap<Employee, EmployeeDto>();


		}
	}
}

using AutoMapper;
using FirstProject_Mvc.DAL.Models;
using FirstProject_Mvc.Pl.ViewsModels;

namespace FirstProject_Mvc.Pl.Helpersprofile
{
	public class MappingProfile :Profile
	{
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}

using AutoMapper;
using RAM_MVC.Models;
using RAM_MVC.Services.Base;

namespace RAM_MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
        }
    }
}

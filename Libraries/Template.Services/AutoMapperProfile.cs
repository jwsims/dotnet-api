using AutoMapper;
using Template.Services.Production.Models;

namespace Template.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AutoMapperProfile, ProductViewModel>();
        }
    }
}

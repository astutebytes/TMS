using AutoMapper;
using TMS.Application.DTOs;
using TMS.Domain.Entities;

namespace TMS.WebApi.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
        }
    }
}

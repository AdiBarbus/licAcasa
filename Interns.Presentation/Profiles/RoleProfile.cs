using AutoMapper;
using Interns.Core.Data;
using Interns.Presentation.DTOs;

namespace Interns.Presentation.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
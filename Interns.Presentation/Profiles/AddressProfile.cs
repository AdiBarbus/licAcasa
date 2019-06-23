using AutoMapper;
using Interns.Core.Data;
using Interns.Presentation.DTOs;

namespace Interns.Presentation.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
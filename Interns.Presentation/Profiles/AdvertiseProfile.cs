using AutoMapper;
using Interns.Core.Data;
using Interns.Presentation.DTOs;

namespace Interns.Presentation.Profiles
{
    public class AdvertiseProfile : Profile
    {
        public AdvertiseProfile()
        {
            CreateMap<Advertise, AdvertiseDto>().ReverseMap();
        }
    }
}
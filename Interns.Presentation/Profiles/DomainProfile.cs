using AutoMapper;
using Interns.Core;
using Interns.Core.Data;
using Interns.Presentation.DTOs;

namespace Interns.Presentation.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Domain, DomainDto>().ReverseMap();

        }
    }
}
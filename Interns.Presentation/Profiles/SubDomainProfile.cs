using AutoMapper;
using Interns.Core.Data;
using Interns.Presentation.DTOs;

namespace Interns.Presentation.Profiles
{
    public class SubDomainProfile : Profile
    {
        public SubDomainProfile()
        {
            CreateMap<SubDomain, SubDomainDto>().ReverseMap();
        }
    }
}
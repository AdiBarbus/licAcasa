using AutoMapper;
using Interns.Core.Data;
using Interns.Presentation.DTOs;

namespace Interns.Presentation.Profiles
{
    public class QaProfile : Profile
    {
        public QaProfile()
        {
            CreateMap<Qa, QaDto>().ReverseMap();
        }
    }
}
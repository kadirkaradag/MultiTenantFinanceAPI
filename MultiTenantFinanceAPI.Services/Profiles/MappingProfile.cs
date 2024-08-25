using AutoMapper;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Services.DTOs;

namespace MultiTenantFinanceAPI.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Issue -> IssueDto haritalaması
            CreateMap<Issue, IssueDto>()
           .ForMember(dest => dest.AgreementName, opt => opt.MapFrom(src => src.Agreement.Name))
           .ReverseMap();

            CreateMap<CreateIssueDto, Issue>().ReverseMap();
            CreateMap<UpdateIssueDto, Issue>().ReverseMap();

            CreateMap<Agreement, AgreementDto>()
              .ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src.Partner.Name))
              .ForMember(dest => dest.Issues, opt => opt.MapFrom(src => src.Issues));  // Issues'u mapliyoruz

            CreateMap<CreateAgreementDto, Agreement>();
            CreateMap<UpdateAgreementDto, Agreement>();

            CreateMap<Partner, PartnerDto>();
            CreateMap<CreatePartnerDto, Partner>();
            CreateMap<UpdatePartnerDto, Partner>();
        }
    }
}

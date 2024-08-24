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

            CreateMap<Agreement, AgreementDto>();
            CreateMap<CreateAgreementDto, Agreement>();
            CreateMap<UpdateAgreementDto, Agreement>();

            CreateMap<Partner, PartnerDto>();
            CreateMap<CreatePartnerDto, Partner>();
            CreateMap<UpdatePartnerDto, Partner>();
        }
    }
}

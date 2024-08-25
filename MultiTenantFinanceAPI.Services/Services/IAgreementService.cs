using MultiTenantFinanceAPI.Services.DTOs;

namespace MultiTenantFinanceAPI.Services.Services
{
    public interface IAgreementService
    {
        Task<IEnumerable<AgreementDto>> GetAllAgreementsAsync();
        Task<AgreementDto> GetAgreementByIdAsync(int id);
        Task<AgreementDto> CreateAgreementAsync(CreateAgreementDto agreementDto);
        Task UpdateAgreementAsync(int id, UpdateAgreementDto agreementDto);
        Task DeleteAgreementAsync(int id);
    }
}

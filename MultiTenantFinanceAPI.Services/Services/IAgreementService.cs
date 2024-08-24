using MultiTenantFinanceAPI.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

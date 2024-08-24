using MultiTenantFinanceAPI.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Services.Services
{
    public interface IPartnerService
    {
        Task<IEnumerable<PartnerDto>> GetAllPartnersAsync();
        Task<PartnerDto> GetPartnerByIdAsync(int id);
        Task<PartnerDto> CreatePartnerAsync(CreatePartnerDto partnerDto);
        Task UpdatePartnerAsync(int id, UpdatePartnerDto partnerDto);
        Task DeletePartnerAsync(int id);
    }
}

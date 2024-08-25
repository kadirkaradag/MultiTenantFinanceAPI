using MultiTenantFinanceAPI.Core.Entities;

namespace MultiTenantFinanceAPI.Core.Interfaces
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> GetByIdAsync(int id);
        Task AddAsync(Partner entity);
        Task UpdateAsync(Partner entity);
        Task DeleteAsync(Partner entity);
    }
}

using MultiTenantFinanceAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Core.Interfaces
{
    public interface IAgreementRepository
    {
        Task<Agreement> GetByIdAsync(int id);
        Task<IEnumerable<Agreement>> GetAllAsync();
        Task AddAsync(Agreement agreement);
        Task UpdateAsync(Agreement agreement);
        Task DeleteAsync(int id);
    }
}

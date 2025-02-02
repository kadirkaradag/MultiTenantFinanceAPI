﻿using MultiTenantFinanceAPI.Core.Entities;

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

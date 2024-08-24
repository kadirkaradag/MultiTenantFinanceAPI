using MultiTenantFinanceAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Core.Interfaces
{
    public interface IIssueRepository
    {
        Task<Issue> GetByIdAsync(int id);
        Task<IEnumerable<Issue>> GetAllAsync();
        Task AddAsync(Issue issue);
        Task UpdateAsync(Issue issue);
        Task DeleteAsync(int id);
    }
}

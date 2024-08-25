using MultiTenantFinanceAPI.Core.Entities;

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

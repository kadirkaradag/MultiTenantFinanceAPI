using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Services.Services
{
    public interface IIssueService
    {
        Task<Issue> GetByIdAsync(int id);
        Task<IEnumerable<Issue>> GetAllAsync();
        Task<Issue> CreateIssueAsync(CreateIssueDto issueDto);
        Task UpdateIssueAsync(int id, UpdateIssueDto issueDto);
        Task DeleteIssueAsync(int id);
        RiskResult AnalyzeRisk(Issue issue);
    }
}

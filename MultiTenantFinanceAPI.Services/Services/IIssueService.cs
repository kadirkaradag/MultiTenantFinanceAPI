using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Entities.Enums;
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
        RiskLevel AnalyzeRisk(Issue issue);
        Task<Issue> GetByIdAsync(int id);
        Task<IEnumerable<Issue>> GetAllAsync();
        Task<Issue> CreateIssueAsync(CreateIssueDto issueDto);
        Task UpdateIssueAsync(int id, UpdateIssueDto issueDto);
        Task DeleteIssueAsync(int id);
    }
}

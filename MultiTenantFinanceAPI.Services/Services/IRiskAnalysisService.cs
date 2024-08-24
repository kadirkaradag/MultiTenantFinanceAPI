using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Services.DTOs;

namespace MultiTenantFinanceAPI.Services.Services
{
    public interface IRiskAnalysisService
    {
        RiskResult AnalyzeRisk(Issue issue);

    }
}

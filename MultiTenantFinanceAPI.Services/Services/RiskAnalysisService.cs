using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Services.DTOs;

namespace MultiTenantFinanceAPI.Services.Services
{
    public class RiskAnalysisService : IRiskAnalysisService
    {
        public RiskResult AnalyzeRisk(Issue issue)
        {
            var riskAmount = CalculateRisk(issue);
            return new RiskResult
            {
                RiskAmount = riskAmount,
                Message = "Risk analiziniz tamamlandı."
            };
        }

        private decimal CalculateRisk(Issue issue)
        {
            decimal riskAmount = 0;
            if (issue.Description.Contains("doğal afet"))
            {
                riskAmount += 10000;
            }
            riskAmount += issue.Agreement.Cost * 0.1m;
            return riskAmount;
        }
    }

}

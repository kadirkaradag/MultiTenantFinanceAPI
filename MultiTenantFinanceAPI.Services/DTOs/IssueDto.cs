using MultiTenantFinanceAPI.Core.Entities.Enums;

namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public decimal Cost { get; set; }
        public decimal AgreementAmount { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public decimal RiskAmount { get; set; }

        public int AgreementId { get; set; }  
        public string AgreementName { get; set; }  
    }


}

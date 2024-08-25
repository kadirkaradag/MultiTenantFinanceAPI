using MultiTenantFinanceAPI.Core.Entities.Enums;
using System.Text.Json.Serialization;

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public decimal Cost { get; set; }
        public decimal AgreementAmount { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public decimal RiskAmount { get; set; }
        public int TenantId { get; set; }

        public int AgreementId { get; set; }  // Agreement ile ilişki
        public Agreement Agreement { get; set; }
    }



}

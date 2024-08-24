using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal RiskAmount { get; set; }
        public int AgreementId { get; set; }
        public Agreement Agreement { get; set; }
        public int TenantId { get; set; }
    }
}

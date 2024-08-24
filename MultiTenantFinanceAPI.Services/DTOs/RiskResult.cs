using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class RiskResult
    {
        public decimal RiskAmount { get; set; }
        public string Message { get; set; }
    }
}

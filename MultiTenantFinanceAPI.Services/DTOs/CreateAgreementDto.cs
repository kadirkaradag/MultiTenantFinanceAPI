using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class CreateAgreementDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public int TenantId { get; set; }

        public DateTime StartDate { get; set; } // Başlama Tarihi
        public DateTime EndDate { get; set; } // Bitiş Tarihi
    }
}

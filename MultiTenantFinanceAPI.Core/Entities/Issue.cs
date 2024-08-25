using MultiTenantFinanceAPI.Core.Entities.Enums;
using System.Text.Json.Serialization;

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; } // İş konusu başlığı
        public string Description { get; set; } // İş konusu açıklaması
        public string Keywords { get; set; } // Anahtar kelimeler, virgülle ayrılmış
        public decimal Cost { get; set; } // Maliyet
        public decimal AgreementAmount { get; set; } // Anlaşma tutarı
        public RiskLevel RiskLevel { get; set; } // Risk seviyesi
        public decimal RiskAmount { get; set; } // Risk miktarı

        public int AgreementId { get; set; }

        [JsonIgnore] // Döngüsel referansları önlemek için
        public Agreement Agreement { get; set; } // İlişkili anlaşma
        public int TenantId { get; set; } // İlişkili iş ortağı
    }

   
}

using System.Text.Json.Serialization;

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public int TenantId { get; set; }

        public DateTime StartDate { get; set; } // Başlama Tarihi
        public DateTime EndDate { get; set; } // Bitiş Tarihi

        [JsonIgnore] // Döngüsel referansları önlemek için
        public ICollection<Issue> Issues { get; set; }
    }
}

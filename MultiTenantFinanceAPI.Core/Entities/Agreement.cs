using System.Text.Json.Serialization;

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TenantId { get; set; }

        public int PartnerId { get; set; }  
        public Partner Partner { get; set; }

        public ICollection<Issue> Issues { get; set; }  
    }

}

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public int TenantId { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}

namespace MultiTenantFinanceAPI.Core.Entities
{    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public int TenantId { get; set; }
        public ICollection<Agreement> Agreements { get; set; }
    }
}

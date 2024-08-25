namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class AgreementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public List<IssueDto> Issues { get; set; }
    }
}

namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class AgreementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public int TenantId { get; set; }

        public DateTime StartDate { get; set; } // Başlama Tarihi
        public DateTime EndDate { get; set; } // Bitiş Tarihi

        public List<IssueDto> Issues { get; set; }
    }
}

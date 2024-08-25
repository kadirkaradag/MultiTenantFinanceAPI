namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class UpdateAgreementDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
    }

}

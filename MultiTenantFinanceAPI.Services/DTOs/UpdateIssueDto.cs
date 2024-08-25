namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class UpdateIssueDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public decimal Cost { get; set; }
        public decimal AgreementAmount { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace MultiTenantFinanceAPI.Services.DTOs
{

    public class CreateIssueDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "RiskAmount must be non-negative")]
        public decimal RiskAmount { get; set; }

        [Required(ErrorMessage = "AgreementId is required")]
        public int AgreementId { get; set; }
    }
}

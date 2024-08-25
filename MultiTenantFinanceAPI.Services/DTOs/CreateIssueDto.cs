using System.ComponentModel.DataAnnotations;

namespace MultiTenantFinanceAPI.Services.DTOs
{
    public class CreateIssueDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Keywords is required")]
        public string Keywords { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Cost must be non-negative")]
        public decimal Cost { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "AgreementAmount must be non-negative")]
        public decimal AgreementAmount { get; set; }

        [Required(ErrorMessage = "AgreementId is required")]
        public int AgreementId { get; set; }       

    }
}

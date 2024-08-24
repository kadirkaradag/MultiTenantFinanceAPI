
using Microsoft.AspNetCore.Identity;

namespace MultiTenantFinanceAPI.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int TenantId { get; set; }
        // Diğer kullanıcı bilgileri burada olabilir
    }
}

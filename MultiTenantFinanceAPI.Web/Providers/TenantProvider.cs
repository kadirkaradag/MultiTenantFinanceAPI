using MultiTenantFinanceAPI.Core.Interfaces;

namespace MultiTenantFinanceAPI.Web.Providers
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int TenantId
        {
            get
            {
                var tenantIdClaim = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == "TenantId");

                if (tenantIdClaim == null)
                {
                    // Hata ayıklama için bir mesaj yazdırın
                    Console.WriteLine("TenantId claim not found.");
                }
                if (tenantIdClaim != null && int.TryParse(tenantIdClaim.Value, out var tenantId))
                {
                    return tenantId;
                }

                throw new Exception("Tenant ID not found in the token");
            }
        }
    }


}

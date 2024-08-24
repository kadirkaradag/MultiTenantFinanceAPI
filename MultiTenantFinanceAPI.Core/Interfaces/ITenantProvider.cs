namespace MultiTenantFinanceAPI.Core.Interfaces
{
    public interface ITenantProvider
    {
        int TenantId { get; }
    }
}

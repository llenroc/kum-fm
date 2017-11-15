namespace Abp.Runtime.Session
{
    public class SessionOverride
    {
        public string UserId { get; }

        public int? TenantId { get; }

        public SessionOverride(int? tenantId, string userId)
        {
            TenantId = tenantId;
            UserId = userId;
        }
    }
}
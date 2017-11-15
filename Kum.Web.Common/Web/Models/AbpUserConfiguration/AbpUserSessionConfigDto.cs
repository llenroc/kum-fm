using Abp.MultiTenancy;

namespace Abp.Web.Models.AbpUserConfiguration
{
    public class AbpUserSessionConfigDto
    {
        public string UserId { get; set; }

        public int? TenantId { get; set; }

        public long? ImpersonatorUserId { get; set; }

        public int? ImpersonatorTenantId { get; set; }

        public MultiTenancySides MultiTenancySide { get; set; }
    }
}
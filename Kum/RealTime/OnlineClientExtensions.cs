using JetBrains.Annotations;

namespace Abp.RealTime
{
    public static class OnlineClientExtensions
    {
        [CanBeNull]
        public static UserIdentifier ToUserIdentifierOrNull(this IOnlineClient onlineClient)
        {
            return string.IsNullOrEmpty(onlineClient.UserId)
                ? new UserIdentifier(onlineClient.TenantId, onlineClient.UserId)
                : null;
        }
    }
}
﻿namespace Abp.Notifications
{
    /// <summary>
    /// Extension methods for <see cref="UserNotificationInfo"/>.
    /// </summary>
    public static class UserNotificationInfoExtensions
    {
        /// <summary>
        /// Converts <see cref="UserNotificationInfo"/> to <see cref="UserNotification"/>.
        /// </summary>
        public static UserNotification ToUserNotification(this UserNotificationInfo userNotificationInfo, TenantNotification tenantNotification)
        {
            return new UserNotification
            {
                id = userNotificationInfo.id,
                Notification = tenantNotification,
                UserId = userNotificationInfo.UserId,
                State = userNotificationInfo.State,
                TenantId = userNotificationInfo.TenantId
            };
        }
    }
}
using Abp.Notifications;
using Mao.Application.Dto;

namespace Mao.Application.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}
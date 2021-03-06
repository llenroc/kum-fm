using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Mao.Application.Friendships.Dto
{
    public class CreateFriendshipRequestInput
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        public int? TenantId { get; set; }
    }
}
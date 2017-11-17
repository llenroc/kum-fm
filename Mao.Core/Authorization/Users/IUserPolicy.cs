using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Mao.Core.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}

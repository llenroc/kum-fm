using System.Threading.Tasks;
using Abp.Application.Services;
using Mao.Application.Sessions.Dto;

namespace Mao.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}


using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Mao.Authorize.UserManager.Dtos;
using Mao.Core.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mao.Application.Base.UserManager
{

    public interface IUserAppService : IApplicationService
    {
        Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetPageUserInput input);
        Task<User> GetUsersAsync(GetUserInput input);
        Task<UserEditDto> CreateOrUpdateUserAsync(CreateOrUpdateUserInput input);
        Task DeleteUserAsync(GetUserInput input);
        Task BatchDeleteUserAsync(List<string> input);

    }
}

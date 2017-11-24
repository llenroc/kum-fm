using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Mao.Application.Authorization.Users.Dto;
using Mao.Application.Dto;
using Abp.Web.Models;
using Mao.Application.Base.UserGroupManager.Dtos;

namespace Mao.Application.Authorization.Users
{
    public interface IUserAppService : IApplicationService
    {
        //Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input);

        //Task<FileDto> GetUsersToExcel();

        //Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input);

        //Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(EntityDto<long> input);

        //Task ResetUserSpecificPermissions(EntityDto<long> input);

        //Task UpdateUserPermissions(UpdateUserPermissionsInput input);

        //Task CreateOrUpdateUser(CreateOrUpdateUserInput input);

        //Task DeleteUser(EntityDto<long> input);

        //Task UnlockUser(EntityDto<long> input);
        //------------------



        #region 获取数据
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+部门+用户树形Json</returns>
        [DontWrapResult]
        object GetTreeJson(GetUsersInput input);

        ///// <summary>
        ///// 用户列表
        ///// </summary>
        ///// <param name="departmentId">部门Id</param>
        ///// <returns>返回用户列表Json</returns>

        //public object GetListJson(string departmentId)
        //{
        //    var data = userCache.GetList(departmentId);
        //    return Content(data.ToJson());
        //}
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [DontWrapResult]
        Task<object> GetPageListJson(UserGroupLRPageDto input);

        /// <summary>
        /// 用户实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        object GetFormJson(long keyValue);

        #endregion
    }
}
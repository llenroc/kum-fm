
using Abp.Application.Services;
using Mao.Application.Base.UserGroupManager.Dtos;
using Mao.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mao.Application.Base.UserGroupManager
{
    /// <summary>
    /// 描 述：用户组管理
    /// </summary>
    public interface IUserGroupLRAppService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        List<RoleLR> GetList();
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns> 
        List<RoleLR> GetPageList(UserGroupLRPageDto input);
        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        List<UserGroupLRListDto> GetAllList();
        /// <summary>
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleLR GetEntity(string keyValue);
        #endregion

    }
}

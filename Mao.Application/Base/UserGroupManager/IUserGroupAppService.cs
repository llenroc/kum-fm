
using Abp.Application.Services;
using Mao.Application.Base.UserGroupManager.Dtos;
using Mao.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mao.Application.Base.UserGroupManager
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：用户组管理
    /// </summary>
    public interface IUserGroupService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleLR> GetList();
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns> 
        IEnumerable<RoleLR> GetPageList(UserGroupListDto input);
        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoleLR>> GetAllList();
        /// <summary>
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleLR GetEntity(string keyValue);
        #endregion

    }
}

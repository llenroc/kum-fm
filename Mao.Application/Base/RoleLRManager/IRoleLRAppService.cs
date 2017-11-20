

using Abp.Application.Services;
using Mao.Application.Base.RoleLRManager.Dtos;
using Mao.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mao.Application.Base.RoleLRManager
{
    /// <summary>
    /// 描 述：角色管理
    /// </summary>
    public interface IRoleLRService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleLR> GetList();
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<RoleLR> GetPageList(RoleLRListDto input);
        /// <summary>
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoleLR>> GetAllListAsync();
        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleLR GetEntity(string RoleId);
        #endregion

    }
}

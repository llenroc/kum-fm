
using Abp.Application.Services;
using Mao.Core.Base;
using System.Collections.Generic;

namespace Mao.Application.Base.OrganizeManager
{
    /// <summary>
    /// 描 述：机构管理
    /// </summary>
    public interface IOrganizeLRAppService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Organize> GetList();
        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Organize GetEntity(string OrganizeId);
        #endregion

    }
}


using Abp.Application.Services;
using Mao.Core.Base;
using System.Collections.Generic;

namespace Mao.Application.Base.OrganizeManager
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.02 14:27
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

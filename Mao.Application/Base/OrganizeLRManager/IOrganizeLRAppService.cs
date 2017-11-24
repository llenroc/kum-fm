
using Abp.Application.Services;
using Abp.Web.Models;
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
        List<Organize> GetList();
        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Organize GetEntity(string OrganizeId);
        #endregion
        /// <summary>
        /// 机构列表 
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        string GetTreeJson(string keyword);

        /// <summary>
        /// 机构列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [DontWrapResult]
        object GetTreeListJson(string condition, string keyword);

        /// <summary>
        /// 机构实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        string GetFormJson(string keyValue);

    }
}


using Abp.Application.Services;
using Abp.Web.Models;
using Mao.Core.Base;
using System.Collections.Generic;

namespace Mao.Application.Base.DepartmentManager
{
    /// <summary>
    /// 描 述：部门管理
    /// </summary>
    public interface IDepartmentLRAppService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        List<Department> GetList();
        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        Department GetEntity(string DepartmentId);
        #endregion



        #region 获取数据
        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形Json</returns>
        [DontWrapResult]
         object GetTreeJson(string organizeId, string keyword);
       
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+部门树形Json</returns>
        [DontWrapResult]
        object GetOrganizeTreeJson(string keyword);

        /// <summary>
        /// 部门列表 
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="keyword">关键字</param>
        /// <returns>返回树形列表Json</returns>
        [DontWrapResult]
        object GetTreeListJson(string condition, string keyword);

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        object GetFormJson(string keyValue);
       

        #endregion
    }
}

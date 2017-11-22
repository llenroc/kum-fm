
using Abp.Application.Services;
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

    }
}

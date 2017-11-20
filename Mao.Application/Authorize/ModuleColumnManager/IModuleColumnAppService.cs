using Abp.Application.Services;
using Mao.Core.Authorize;
using System.Collections.Generic;

namespace Mao.Application.Authorize.ModuleColumnManager
{
    /// <summary>
    /// 描 述：系统视图
    /// </summary>
    public interface IModuleColumnAppService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        List<ModuleColumn> GetList();
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        List<ModuleColumn> GetList(string moduleId);
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleColumn GetEntity(string ModuleColumnId);
        #endregion

        
    }
}

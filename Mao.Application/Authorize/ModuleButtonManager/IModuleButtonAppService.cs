using Abp.Application.Services;
using Mao.Core.Authorize;
using System.Collections.Generic;

namespace Mao.Application.Authorize.ModuleButtonManager
{
    /// <summary>
    /// 描 述：系统按钮
    /// </summary>
    public interface IModuleButtonAppService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        List<ModuleButton> GetList();
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        List<ModuleButton> GetList(string moduleId);
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleButton GetEntity(string ModuleButtonId);
        #endregion

        
    }
}

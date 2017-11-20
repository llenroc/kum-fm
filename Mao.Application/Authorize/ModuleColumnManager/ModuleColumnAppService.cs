using Abp.Dependency;
using Abp.Domain.Repositories;
using Mao.Application;
using Mao.Core.Authorize;
using Mao.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Mao.Application.Authorize.ModuleColumnManager
{
    /// <summary>
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnAppService : MaoAppServiceBase, IModuleColumnAppService
    {

        private readonly ISqlExecuter _sqlExecuter;
        private readonly IRepository<ModuleColumn> _moduleColumn;

        public ModuleColumnAppService(

        IRepository<ModuleColumn> moduleColumn
            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;
            _moduleColumn = moduleColumn;

        }

        #region 获取数据
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <returns></returns>
        public List<ModuleColumn> GetList()
        {
            return _moduleColumn.GetAll().OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<ModuleColumn> GetList(string moduleId)
        {
            var res = _moduleColumn.GetAll().Where(t => t.ModuleId.Equals(moduleId)).ToList();
            return res;
        }
        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumn GetEntity(string ModuleColumnId)
        {
            return _moduleColumn.FirstOrDefault(a => a.ModuleColumnId == ModuleColumnId);
        }
        #endregion

        
    }
}

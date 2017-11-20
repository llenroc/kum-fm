
using Abp.Dependency;
using Abp.Domain.Repositories;

using Mao.Application;
using Mao.Core.Authorize;
using Mao.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Mao.Application.Authorize.ModuleButtonManager
{
    /// <summary>
    /// 描 述：系统按钮
    /// </summary>
    public class ModuleButtonAppService : MaoAppServiceBase, IModuleButtonAppService
    {
        private readonly ISqlExecuter _sqlExecuter;
        private readonly IRepository<ModuleButton> _moduleButton;

        public ModuleButtonAppService(

        IRepository<ModuleButton> moduleButton
            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;
            _moduleButton = moduleButton;

        }



        #region 获取数据
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        public List<ModuleButton> GetList()
        {
            return _moduleButton.GetAll().OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<ModuleButton> GetList(string moduleId)
        {
            var res = _moduleButton.GetAll().Where(t => t.ModuleId.Equals(moduleId)).ToList();
            return res;
        }
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButton GetEntity(string ModuleButtonId)
        {
            return _moduleButton.FirstOrDefault(a => a.ModuleButtonId == ModuleButtonId);
        }
        #endregion


    }
}

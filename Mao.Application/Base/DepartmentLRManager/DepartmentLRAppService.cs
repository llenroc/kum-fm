using Abp.Dependency;
using Abp.Domain.Repositories;
using Mao.Application;
using Mao.Core.Base;
using Mao.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Mao.Application.Base.DepartmentManager
{
    /// <summary>
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentLRAppService : MaoAppServiceBase, IDepartmentLRAppService
    {



        private IRepository<Department> _department;
        private readonly ISqlExecuter _sqlExecuter;

        public DepartmentLRAppService(
             IRepository<Department> department

            )
        {

            _department = department;

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetList()
        {
          return  _department.GetAll().OrderByDescending(t => t.CreationTime).ToList();
        }
        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Department GetEntity(string DepartmentId)
        {
            return _department.FirstOrDefault(a => a.DepartmentId == DepartmentId);
        }
        #endregion

    }
}

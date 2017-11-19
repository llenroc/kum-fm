using Abp.Dependency;
using Abp.Domain.Repositories;

using Mao.Application;
using Mao.Core.Base;
using Mao.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mao.Application.Base.OrganizeManager
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.02 14:27
    /// 描 述：机构管理
    /// </summary>
    public class OrganizeLRAppService : MaoAppServiceBase, IOrganizeLRAppService
    {
        private IRepository<Organize> _organize;
        private readonly ISqlExecuter _sqlExecuter;

        public OrganizeLRAppService(
             IRepository<Organize> organize

            )
        {

            _organize = organize;

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Organize> GetList()
        {
            var res = _organize.GetAll().OrderByDescending(t => t.SortCode).ToList();
            return res;
        }
        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public Organize GetEntity(string OrganizeId)
        {
            var res = _organize.FirstOrDefault(a => a.OrganizeId == OrganizeId);
            return res;
        }
        #endregion


    }
}


using Abp.Dependency;
using Abp.Domain.Repositories;
using LeaRun.Application.IService.BaseManage;

using Mao.Application;
using Mao.Application.Base.JobLRManager.Dtos;
using Mao.Core.Base;
using Mao.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
namespace LeaRun.Application.Service.BaseManage
{
    /// <summary>
    /// 描 述：职位管理
    /// </summary>
    public class JobLRService : MaoAppServiceBase, IJobLRService
    {

        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public JobLRService(


            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleLR> GetList()
        {
            var res = _roleLR.GetAll().Where(t => t.Category == 3 && t.EnabledMark == 1 && t.DeleteMark == 0);
            return res;
        }
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleLR> GetPageList(JobLRListDto input)
        {
            var query = _roleLR.GetAll();

            if (input.FullName != "")
            {
                query.Where(a => a.FullName == input.FullName);
            }
            if (input.EnCode != "")
            {
                query.Where(a => a.EnCode == input.EnCode);
            }
            query.Where(a => a.Category == 3);
            var res = query.OrderBy(input.Sorting).PageBy(input);


            return res.AsEnumerable();
           
        }
        /// <summary>
        /// 职位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleLR GetEntity(string RoleId)
        {
            return _roleLR.FirstOrDefault(a => a.RoleId == RoleId);
        }
        #endregion


    }
}

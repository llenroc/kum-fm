
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
using Abp.Web.Models;
using Mao.Application.Base.RoleLRManager.Dtos;
using Mao.Util.Extension;
using Mao;

namespace LeaRun.Application.Service.BaseManage
{
    /// <summary>
    /// 描 述：职位管理
    /// </summary>
    public class JobLRAppService : MaoAppServiceBase, IJobLRAppService
    {

        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public JobLRAppService(

             IRepository<RoleLR> roleLR
            )
        {
            _roleLR = roleLR;
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



        #region 获取数据
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [DontWrapResult]
        public object GetPageListJson(JobLRPageDto input)
        {
            var watch = CommonHelper.TimerStart();

            var query = _roleLR.GetAll();

            if (!string.IsNullOrEmpty(input.FullName))
            {
                query.Where(a => a.FullName == input.FullName);
            }
            if (!string.IsNullOrEmpty(input.EnCode))
            {
                query.Where(a => a.EnCode == input.EnCode);
            }
            int records = 0;
            int total = 0;
            var rows = query.Where(a => a.Category == 3).OrderBy(input.Sorting).PageBy(MaoConsts.DefaultPageSize, input.page, out records, out total).AsEnumerable();


            var JsonData = new
            {
                rows = rows,
                total = total,
                page = input.page,
                records = records,
                costtime = CommonHelper.TimerEnd(watch)
            };


            return Newtonsoft.Json.JsonConvert.DeserializeObject(JsonData.ToJson());
        }
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns>返回列表Json</returns>
        [DontWrapResult]
        public object GetListJson(string organizeId)
        {
            var data = _roleLR.GetAllList(a => a.OrganizeId == organizeId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson());
        }
        /// <summary>
        /// 职位实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        public object GetFormJson(string keyValue)
        {
            var data = GetEntity(keyValue);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson());
        }
        #endregion

    }
}

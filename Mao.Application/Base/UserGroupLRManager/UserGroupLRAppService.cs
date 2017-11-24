using Abp.Authorization.Users;
using Abp.Dependency;
using Abp.Domain.Repositories;

using Mao.Application.Base.RoleLRManager.Dtos;
using Mao.Core.Base;
using Mao.Extensions;
using Mao.Util.Extension;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using Mao.Application.Base.UserGroupManager.Dtos;
using Abp.AutoMapper;
using Abp.Web.Models;

namespace Mao.Application.Base.UserGroupManager
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：用户组管理
    /// </summary>
    public class UserGroupLRAppService : MaoAppServiceBase, IUserGroupLRAppService
    {
        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public UserGroupLRAppService(
            IRepository<RoleLR> roleLR
            )
        {

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

            _roleLR = roleLR;
        }
        #region 获取数据
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public List<RoleLR> GetList()
        {


            var res = _roleLR.GetAll().Where(t => t.Category == 4 && t.EnabledMark == 1 && t.DeleteMark == 0);
            return res.ToList();

        }
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public List<RoleLR> GetPageList(UserGroupLRListDto input)
        {
            var query = _roleLR.GetAll();

            if (input.FullName != "")
            {
                query = query.Where(a => a.FullName == input.FullName);
            }
            if (input.EnCode != "")
            {
                query = query.Where(a => a.EnCode == input.EnCode);
            }
            var res = query.Where(a => a.Category == 4).OrderBy(input.Sorting).PageBy(input);





            return res.AsEnumerable().ToList
                ();
        }
        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        public List<UserGroupLRListDto> GetAllList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  r.RoleId ,
				                    o.FullName AS OrganizeId ,
				                    r.Category ,
				                    r.EnCode ,
				                    r.FullName ,
				                    r.SortCode ,
				                    r.EnabledMark ,
				                    r.Description ,
				                    r.CreationTime
                    FROM    Base_RoleLR r
				                    LEFT JOIN Base_Organize o ON o.OrganizeId = r.OrganizeId
                    WHERE   o.FullName is not null and r.Category = 4 and r.EnabledMark =1
                    ORDER BY o.FullName, r.SortCode");

            var r = _sqlExecuter.SqlQuery<UserGroupLRListDto>(strSql.ToString());

                List<UserGroupLRListDto> role = r.MapTo<List<UserGroupLRListDto>>();
            return role;
           
        }
        /// <summary>
        /// 用户组实体
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
        /// 用户组列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns>返回列表Json</returns>
        [DontWrapResult]
        public object GetListJson(string organizeId)
        {
            var data = _roleLR.GetAllList(a=>a.OrganizeId == organizeId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson());
        }
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [DontWrapResult]
        public object GetPageListJson(UserGroupLRPageDto input)
        {
            //var data = userGroupBLL.GetPageList(pagination, queryJson);
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
            var rows = query.Where(a => a.Category == 4).OrderBy(input.Sorting).PageBy(MaoConsts.DefaultPageSize, input.page, out records, out total).AsEnumerable();


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
        /// 用户组实体 
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

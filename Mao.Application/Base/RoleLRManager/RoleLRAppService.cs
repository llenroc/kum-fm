
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Mao.Application;
using Abp.Domain.Repositories;
using Mao.Core.Base;
using Mao.Extensions;
using Abp.Dependency;
using System.Linq.Dynamic;
using Mao.Application.Base.RoleLRManager.Dtos;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Mao.Application.Base.PostLRManager.Dtos;
using Abp.Web.Models;
using Mao.Util.Extension;
using System;


namespace Mao.Application.Base.RoleLRManager
{
    /// <summary>
    /// 描 述：角色管理
    /// </summary>
    public class RoleLRAppService : MaoAppServiceBase, IRoleLRAppService
    {
        //private IAuthorizeService<RoleLR> iauthorizeservice = new AuthorizeService<RoleLR>();
        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public RoleLRAppService(
           IRepository<RoleLR> roleLR
            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;
            _roleLR = roleLR;
        }


        #region 获取数据
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleLR> GetList()
        {

            var res = _roleLR.GetAll().Where(t => t.Category == 1 && t.EnabledMark == 1 && t.DeleteMark == 0);
            return res.ToList();
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        //public List<RoleLR> GetPageList(RoleLRPageDto input)
        //{




        //}
        /// <summary>
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        public List<RoleLRListDto> GetAllList()
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
                    WHERE   o.FullName is not null and r.Category = 1 and r.EnabledMark =1
                    ORDER BY o.FullName, r.SortCode");




            var Module = _sqlExecuter.SqlQuery<RoleLRListDto>(strSql.ToString());
            List<RoleLRListDto> role = Module.MapTo<List<RoleLRListDto>>();
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
        /// 角色列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns>返回列表Json</returns>
        [DontWrapResult]
        public object GetListJson(string organizeId)
        {
            var data = _roleLR.GetAllList(a => a.OrganizeId == organizeId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson());
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [DontWrapResult]
        public object GetPageListJson(RoleLRPageDto input)
        {
            //List<RoleLR>JsonData = GetPageList(input);

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
            var rows = query.Where(a => a.Category == 1).OrderBy(input.Sorting).PageBy(MaoConsts.DefaultPageSize, input.page, out records,out total).AsEnumerable();


            //return res.ToList();

          

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
        /// 角色实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        public object GetFormJson(string keyValue)
        {
            var data = GetEntity(keyValue);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson("yyyy-MM-dd HH:mm"));
        }
        #endregion

    }
}

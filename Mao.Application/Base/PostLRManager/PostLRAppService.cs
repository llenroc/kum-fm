﻿using Abp.Dependency;
using Abp.Domain.Repositories;

using Mao.Application;
using Mao.Application.Base.PostLRManager.Dtos;
using Mao.Core.Base;
using Mao.Extensions;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
namespace Mao.Application.Base.RoleLRManager
{
    /// <summary>
    /// 描 述：岗位管理
    /// </summary>
    public class PostLRAppService : MaoAppServiceBase, IPostService
    {

        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public PostLRAppService(


            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleLR> GetList()
        {
            var res = _roleLR.GetAll().Where(t => t.Category == 2 && t.EnabledMark == 1 && t.DeleteMark == 0);
            return res;
           
        }
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleLR> GetPageList(PostLRListDto input)
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
            query.Where(a => a.Category == 2);
            var res = query.OrderBy(input.Sorting).PageBy(input);


            return res.AsEnumerable();
           
        }
        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoleLR>> GetAllListAsync()
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
				                    r.CreateDate
                    FROM    Base_Role r
				                    LEFT JOIN Base_Organize o ON o.OrganizeId = r.OrganizeId
                    WHERE   o.FullName is not null and r.Category = 2 and r.EnabledMark =1
                    ORDER BY o.FullName, r.SortCode");




            var Module = await _sqlExecuter.SqlQueryAsync<RoleLR>(strSql.ToString());

            return Module;
            
        }
        /// <summary>
        /// 岗位实体
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

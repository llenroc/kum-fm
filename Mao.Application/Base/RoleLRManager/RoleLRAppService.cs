
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

namespace Mao.Application.Base.RoleLRManager
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：角色管理
    /// </summary>
    public class RoleLRService : MaoAppServiceBase, IRoleLRService
    {
        //private IAuthorizeService<RoleLR> iauthorizeservice = new AuthorizeService<RoleLR>();
        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public RoleLRService(


            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }
        #region 获取数据
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleLR> GetList()
        {

            var res = _roleLR.GetAll().Where(t => t.Category == 1 && t.EnabledMark == 1 &&  t.DeleteMark == 0);
            return res;
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleLR> GetPageList(RoleLRListDto input)
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
            query.Where(a => a.Category == 1);
            var res = query.OrderBy(input.Sorting).PageBy(input);

            
            return res.AsEnumerable();

           
            





           
        }
        /// <summary>
        /// 角色列表all
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
                    WHERE   o.FullName is not null and r.Category = 1 and r.EnabledMark =1
                    ORDER BY o.FullName, r.SortCode");

          


            var Module = await _sqlExecuter.SqlQueryAsync<RoleLR>(strSql.ToString());

            return Module;

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


    }
}

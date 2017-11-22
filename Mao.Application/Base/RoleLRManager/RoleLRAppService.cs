
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

namespace Mao.Application.Base.RoleLRManager
{
    /// <summary>
    /// 描 述：角色管理
    /// </summary>
    public class RoleLRService : MaoAppServiceBase, IRoleLRService
    {
        //private IAuthorizeService<RoleLR> iauthorizeservice = new AuthorizeService<RoleLR>();
        private IRepository<RoleLR> _roleLR;
        private readonly ISqlExecuter _sqlExecuter;

        public RoleLRService(
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
        public List<RoleLR> GetPageList(RoleLRPageDto input)
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


            return res.ToList();









        }
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


    }
}

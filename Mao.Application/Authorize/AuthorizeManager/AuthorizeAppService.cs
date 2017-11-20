
using Abp.Dependency;
using Abp.Domain.Repositories;
using Mao;
using Mao.Application;
using Mao.Application.Authorize.AuthorizeManager;
using Mao.Application.Code;
using Mao.Core.Authorization.Users;
using Mao.Core.Authorize;
using Mao.Core.Base;
using Mao.Extensions;
using Mao.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao.Application.Authorize.AuthorizeManager
{
    public class AuthorizeAppService : MaoAppServiceBase, IAuthorizeAppService
    {
        private readonly ISqlExecuter _sqlExecuter;
        private readonly IRepository<UserRelation> _userRelation;
        private readonly IRepository<AuthorizeData> _authorizeData;

        public AuthorizeAppService(
           IRepository<UserRelation> userRelation,
        IRepository<AuthorizeData> authorizeData
            )
        {
            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;
            _userRelation = userRelation;
            _authorizeData = authorizeData;
        }


        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<Module>> GetModuleListAsync(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");

            //object[] parameter = { userId };


            DbParameter[] parameter =
           {
                DbParameters.CreateDbParameter("@UserId",userId)
            };


            var Module = await _sqlExecuter.SqlQueryAsync<Module>(strSql.ToString(), parameter);

            return Module;
        }
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<ModuleButton>> GetModuleButtonListAsync(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId ) Order By SortCode");

           
            DbParameter[] parameter =
          {
                DbParameters.CreateDbParameter("@UserId",userId)
            };

            var ModuleButton = await _sqlExecuter.SqlQueryAsync<ModuleButton>(strSql.ToString(), parameter);


            return ModuleButton;
        }
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<ModuleColumn>> GetModuleColumnListAsync(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleColumn
                            WHERE   ModuleColumnId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )  Order By SortCode");
            DbParameter[] parameter =
         {
                DbParameters.CreateDbParameter("@UserId",userId)
            };

            var ModuleColumn = await _sqlExecuter.SqlQueryAsync<ModuleColumn>(strSql.ToString(), parameter);


            return ModuleColumn;
        }
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<AuthorizeUrlModel>> GetUrlListAsync(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  ModuleId AS AuthorizeId ,
                                    ModuleId ,
                                    UrlAddress ,
                                    FullName
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND EnabledMark = 1
                                    AND DeleteMark = 0
                                    AND IsMenu = 1
                                    AND UrlAddress IS NOT NULL
                            UNION
                            SELECT  ModuleButtonId AS AuthorizeId ,
                                    ModuleId ,
                                    ActionAddress AS UrlAddress ,
                                    FullName
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND ActionAddress IS NOT NULL");

            DbParameter[] parameter =
       {
                DbParameters.CreateDbParameter("@UserId",userId)
            };

            var AuthorizeUrlModel = await _sqlExecuter.SqlQueryAsync<AuthorizeUrlModel>(strSql.ToString(), parameter);


            return AuthorizeUrlModel;
        }
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<UserRelation> GetUserRelationList(string userId)
        {
            return _userRelation.GetAll().Where(a => a.UserId == userId);
        }
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public async Task<string> GetDataAuthorUserId(Operator operators, bool isWrite = false)
        {
            string userIdList = await GetDataAuthorAsync(operators, isWrite);
            if (userIdList == "")
            {
                return "";
            }
            //IRepository db = new RepositoryFactory().BaseRepository();
            long userId = operators.UserId;

            List<User> userList = await UserManager.FindAllAsync();
            //UserManager. <User>(userIdList).ToList();
            StringBuilder userSb = new StringBuilder("");
            if (userList != null)
            {
                foreach (var item in userList)
                {
                    userSb.Append(item.Id);
                    userSb.Append(",");
                }
            }
            return userSb.ToString();
        }
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public async Task<string> GetDataAuthorAsync(Operator operators, bool isWrite = false)
        {
            //如果是系统管理员直接给所有数据权限
            if (operators.IsSystem)
            {
                return "";
            }
            //IRepository db = new RepositoryFactory().BaseRepository();
            long userId = operators.UserId;
            StringBuilder whereSb = new StringBuilder(" select Id from Main_user where 1=1 ");
            string strAuthorData = "";
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     IsRead=0 AND
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId =@UserId)";
            }
            else
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId =@UserId)";
            }
         
            whereSb.Append(string.Format("AND( UserId ='{0}'", userId));

            DbParameter[] parameter =
       {
                DbParameters.CreateDbParameter("@UserId",userId)
            };

            List<AuthorizeData> listAuthorizeData =await _sqlExecuter.SqlQueryAsync<AuthorizeData>(whereSb.ToString(), parameter);


            foreach (AuthorizeData item in listAuthorizeData)
            {
                switch (item.AuthorizeType)
                {
                    //0代表最大权限
                    case 0://
                        return "";
                    //本人及下属
                    case -2://
                        whereSb.Append("  OR ManagerId ='{0}'");
                        break;
                    case -3:
                        whereSb.Append(@"  OR DepartmentId = (  SELECT  DepartmentId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )");
                        break;
                    case -4:
                        whereSb.Append(@"  OR OrganizeId = (    SELECT  OrganizeId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )");
                        break;
                    case -5:
                        whereSb.Append(string.Format(@"  OR DepartmentId='{1}' OR OrganizeId='{1}'", userId, item.ResourceId));
                        break;
                }
            }
            whereSb.Append(")");
            return whereSb.ToString();
        }

       
    }
}

﻿
using Abp.AutoMapper;
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
        public List<Module> GetModuleList()
        {
            string userId = AbpSession.UserId.ToString();
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


            var Module = _sqlExecuter.SqlQuery<Module>(strSql.ToString(), parameter);

            return Module.MapTo<List<Module>>();
        }
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public Dictionary<string, object> GetModuleButtonList()
        {
            string userId = AbpSession.UserId.ToString();
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

            var data = _sqlExecuter.SqlQuery<ModuleButton>(strSql.ToString(), parameter).ToList();



            var dataModule = data.Where((x, i) => data.FindIndex(z => z.ModuleId == x.ModuleId) == i).ToList(); 
            //= data.Distinct(new Comparint<ModuleButton>("ModuleId")).ToList();





            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            foreach (ModuleButton item in dataModule)
            {

                var buttonList = data.Where(t => t.ModuleId==item.ModuleId);

                dictionary.Add(item.ModuleId, buttonList);
            }



            return dictionary;

            //return ModuleButton.MapTo<List<ModuleButton>>();
        }
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public Dictionary<string, object> GetModuleColumnList()
        {
            string userId = AbpSession.UserId.ToString();
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

            var data = _sqlExecuter.SqlQuery<ModuleColumn>(strSql.ToString(), parameter).ToList();

            var dataModule = data.Where((x, i) => data.FindIndex(z => z.ModuleId == x.ModuleId) == i).ToList();

            //var dataModule = data.Distinct(new Comparint<ModuleColumn>("ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleColumn item in dataModule)
            {
                var columnList = data.Where(t => t.ModuleId.Equals(item.ModuleId));
                dictionary.Add(item.ModuleId, columnList);
            }
            return dictionary;

        }
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<AuthorizeUrlModel> GetUrlList(string userId)
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

            var AuthorizeUrlModel = _sqlExecuter.SqlQuery<AuthorizeUrlModel>(strSql.ToString(), parameter);


            return AuthorizeUrlModel.MapTo<List<AuthorizeUrlModel>>();
        }
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<UserRelation> GetUserRelationList(string userId)
        {
            return _userRelation.GetAll().Where(a => a.UserId == userId).ToList();
        }
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public async Task<string> GetDataAuthorUserIdAsync(Operator operators, bool isWrite = false)
        {
            string userIdList = GetDataAuthor(operators, isWrite);
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
        public string GetDataAuthor(Operator operators, bool isWrite = false)
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


            IEnumerable<AuthorizeData> listAuthorizeData = _sqlExecuter.SqlQuery<AuthorizeData>(whereSb.ToString(), parameter);

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


















        //private IAuthorizeService service = new AuthorizeService();




        /// <summary>
        /// Action执行权限认证
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleId">模块Id</param>
        /// <param name="action">请求地址</param>
        /// <returns></returns>
        public bool ActionAuthorize(string userId, string moduleId, string action)
        {
            List<AuthorizeUrlModel> authorizeUrlList = new List<AuthorizeUrlModel>();

            authorizeUrlList = GetUrlList(userId);

            authorizeUrlList = authorizeUrlList.FindAll(t => t.ModuleId.Equals(moduleId));
            foreach (AuthorizeUrlModel item in authorizeUrlList)
            {
                if (!string.IsNullOrEmpty(item.UrlAddress))
                {
                    string[] url = item.UrlAddress.Split('?');
                    if (item.ModuleId == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}

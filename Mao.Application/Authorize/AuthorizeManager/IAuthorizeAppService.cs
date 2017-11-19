
using Abp.Application.Services;
using Mao.Application.Code;
using Mao.Core.Authorize;
using Mao.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mao.Application.Authorize.AuthorizeManager
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.5 22:35
    /// 描 述：授权认证
    /// </summary>
    public interface IAuthorizeAppService : IApplicationService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task<IEnumerable<Module>> GetModuleListAsync(string userId);
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task<IEnumerable<ModuleButton>> GetModuleButtonListAsync(string userId);
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task<IEnumerable<ModuleColumn>> GetModuleColumnListAsync(string userId);
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task<IEnumerable<AuthorizeUrlModel>> GetUrlListAsync(string userId);
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<UserRelation> GetUserRelationList(string userId);
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        Task<string> GetDataAuthorUserId(Operator operators, bool isWrite = false);
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        Task<string> GetDataAuthorAsync(Operator operators, bool isWrite = false);
    }
}

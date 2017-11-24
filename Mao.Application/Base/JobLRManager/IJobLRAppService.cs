using Abp.Application.Services;
using Abp.Web.Models;
using Mao.Application.Base.JobLRManager.Dtos;
using Mao.Application.Base.RoleLRManager.Dtos;
using Mao.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：职位管理
    /// </summary>
    public interface IJobLRAppService : IApplicationService
    {
        #region 获取数据
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleLR> GetList();
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<RoleLR> GetPageList(JobLRListDto inpuit);
        /// <summary>
        /// 职位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleLR GetEntity(string keyValue);
        #endregion

        #region 获取数据
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [DontWrapResult]
        object GetPageListJson(JobLRPageDto input);

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="organizeId">机构Id</param>
        /// <returns>返回列表Json</returns>
        [DontWrapResult]
        object GetListJson(string organizeId);

        /// <summary>
        /// 职位实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        object GetFormJson(string keyValue);

        #endregion

    }
}

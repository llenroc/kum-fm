

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Mao.Application.Person.Dtos;
using System.Linq;


#region 代码生成器相关信息_ABP Code Generator Info
//你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
//我的邮箱:werltm@hotmail.com
// 官方网站:"http://www.yoyocms.com"
// 交流QQ群：104390185  
//微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2017-09-25T13:03:29. All Rights Reserved.
//<生成时间>2017-09-25T13:03:29</生成时间>
#endregion
namespace Mao.Application.Person
{
    /// <summary>
    /// 资质管理服务接口
    /// </summary>
    public interface IPersonAppService : IApplicationService
    {


        Task<PagedResultDto<PersonListDto>> GetAllAsync(GetPersonInput input);

        #region add by clt


        /// <summary>
        /// 证书列表
        /// </summary>
        Task<PagedResultDto<object>> GetCertificateAndUserAsync(GetPersonInput input);


        /// <summary>
        /// 获取用户证书列表
        /// </summary>
        Task<PagedResultDto<PersonListDto>> GetCertificateAsync(GetPersonInput input);



        #endregion
        #region 资质管理管理

        /// <summary>
        /// 根据查询条件获取资质管理分页列表
        /// </summary>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonsAsync(GetPersonInput input);

        /// <summary>
        /// 通过Id获取资质管理信息进行编辑或修改 
        /// </summary>
        Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取资质管理ListDto信息
        /// </summary>
        Task<PersonListDto> GetPersonByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改资质管理
        /// </summary>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);





        /// <summary>
        /// 新增资质管理
        /// </summary>
        Task<PersonEditDto> CreatePersonAsync(PersonEditDto input);

        /// <summary>
        /// 更新资质管理
        /// </summary>
        Task UpdatePersonAsync(PersonEditDto input);

        /// <summary>
        /// 删除资质管理
        /// </summary>
        Task DeletePersonAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除资质管理
        /// </summary>
        Task BatchDeletePersonAsync(List<int> input);

        #endregion




    }
}

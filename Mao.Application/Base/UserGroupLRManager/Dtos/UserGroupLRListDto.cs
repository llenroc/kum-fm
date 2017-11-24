
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

using System.Collections.Generic;
using Mao;
using Mao.Core.Base;
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
// Copyright © YoYoCms@China.2017-09-25T13:03:25. All Rights Reserved.
//<生成时间>2017-09-25T13:03:25</生成时间>
#endregion
namespace Mao.Application.Base.UserGroupManager.Dtos
{

    /// <summary>
    /// 资质管理列表Dto
    /// </summary>
    public class UserGroupLRListDto: PagedAndSortedInputDto
    {
        #region 实体成员
        /// <summary>
        /// 角色主键
        /// </summary>		
        public string RoleId { get; set; }
        /// <summary>
        /// 机构主键
        /// </summary>		
        public string OrganizeId { get; set; }
        /// <summary>
        /// 分类1-角色2-岗位3-职位4-工作组
        /// </summary>		
        public int? Category { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>		
        public string EnCode { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>		
        public string FullName { get; set; }
        /// <summary>
        /// 公共角色
        /// </summary>		
        public int? IsPublic { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>		
        public DateTime? OverdueTime { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>		
        public int? DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>		
        public int? EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Description { get; set; }

        public DateTime? CreationTime { get; set; }


        #endregion


    }




}

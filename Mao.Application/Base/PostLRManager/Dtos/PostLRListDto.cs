﻿
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

using System.Collections.Generic;
using Mao;
using Mao.Core.Base;

namespace Mao.Application.Base.PostLRManager.Dtos
{
	/// <summary>
    /// 资质管理列表Dto
    /// </summary>
    public class PostLRListDto : PagedAndSortedInputDto
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

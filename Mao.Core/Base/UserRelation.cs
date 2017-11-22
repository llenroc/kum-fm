using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mao.Core.Base 
{
    public partial class UserRelation : FullAuditedEntity
    {
        [MaxLength(50)]
        #region 实体成员
        /// <summary>
        /// 用户关系主键
        /// </summary>		
        public string UserRelationId { get; set; }
        /// <summary>
        /// 用户主键
        /// </summary>		
        public string UserId { get; set; }
        /// <summary>
        /// 分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>		
        public int? Category { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>		
        public string ObjectId { get; set; }
        /// <summary>
        /// 默认对象
        /// </summary>
        public int? IsDefault { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int SortCode { get; set; }
       
        #endregion

        
    }
}
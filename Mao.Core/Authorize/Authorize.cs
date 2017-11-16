using Abp.Domain.Entities.Auditing;
using Mao.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Mao.Core.Authorize
{

    public partial class Authorize : FullAuditedEntity
    {
        #region 实体成员
        /// <summary>
        /// 授权功能主键
        /// </summary>		
        [MaxLength(50)]
        public string AuthorizeId { get; set; }
        /// <summary>
        /// 对象分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>		
        public int? Category { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>		
        public string ObjectId { get; set; }
        /// <summary>
        /// 项目类型:1-菜单2-按钮3-视图4表单
        /// </summary>		
        public int? ItemType { get; set; }
        /// <summary>
        /// 项目主键
        /// </summary>		
        public string ItemId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode { get; set; }
        
        #endregion

        
    }
}
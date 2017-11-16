using Abp.Domain.Entities.Auditing;
using Mao.Core.Base;
namespace Mao.Core.Authorize
{

    public partial class FilterIP : FullAuditedEntity
    {
        #region 实体成员
        /// <summary>
        /// 过滤IP主键
        /// </summary>		
        public string FilterIPId { get; set; }
        /// <summary>
        /// 对象类型
        /// </summary>		
        public string ObjectType { get; set; }
        /// <summary>
        /// 对象Id
        /// </summary>		
        public string ObjectId { get; set; }
        /// <summary>
        /// 访问
        /// </summary>		
        public int? VisitType { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public int? Type { get; set; }
        /// <summary>
        /// IP访问
        /// </summary>		
        public string IPLimit { get; set; }
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
       
        #endregion

        
    }
}
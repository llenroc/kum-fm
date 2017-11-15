using Abp.Domain.Entities.Auditing;
using System;

namespace Mao.Core.Authorize
{

    public partial class FilterTimeEntity : FullAuditedEntity
    {
        #region 实体成员
        /// <summary>
        /// 过滤时段主键
        /// </summary>		
        public string FilterTimeId { get; set; }
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
        /// 星期一
        /// </summary>		
        public string WeekDay1 { get; set; }
        /// <summary>
        /// 星期二
        /// </summary>		
        public string WeekDay2 { get; set; }
        /// <summary>
        /// 星期三
        /// </summary>		
        public string WeekDay3 { get; set; }
        /// <summary>
        /// 星期四
        /// </summary>		
        public string WeekDay4 { get; set; }
        /// <summary>
        /// 星期五
        /// </summary>		
        public string WeekDay5 { get; set; }
        /// <summary>
        /// 星期六
        /// </summary>		
        public string WeekDay6 { get; set; }
        /// <summary>
        /// 星期日
        /// </summary>		
        public string WeekDay7 { get; set; }
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

using Abp.Domain.Entities.Auditing;
using System;

namespace Mao.Core.Authorize
{
    public partial class ModuleFormEntity: FullAuditedEntity
    {
        #region 实体成员
        /// <summary>
        /// 表单主键
        /// </summary>
        public string FormId { set; get; }
        /// <summary>
        /// 功能主键
        /// </summary>
        public string ModuleId { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { set; get; }
        /// <summary>
        /// 表单控件Json
        /// </summary>
        public string FormJson { set; get; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { set; get; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeleteMark { set; get; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public int? EnabledMark { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { set; get; }
        
        #endregion

        
    }
}

using Abp.Domain.Entities;

namespace Mao.Core.Authorize
{

    public partial class ModuleButton : Entity
    {
        #region 实体成员
        /// <summary>
        /// 按钮主键
        /// </summary>		
        public string ModuleButtonId { get; set; }
        /// <summary>
        /// 功能主键
        /// </summary>		
        public string ModuleId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>		
        public string ParentId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>		
        public string Icon { get; set; }
        /// <summary>
        /// 编码
        /// </summary>		
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string FullName { get; set; }
        /// <summary>
        /// Action地址
        /// </summary>		
        public string ActionAddress { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode { get; set; }
        #endregion

        
    }
}
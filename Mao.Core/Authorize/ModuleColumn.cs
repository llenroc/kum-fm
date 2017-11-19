using Abp.Domain.Entities;

namespace Mao.Core.Authorize
{ 
    public partial class ModuleColumn : Entity 
    {
        #region 实体成员
        /// <summary>
        /// 列主键
        /// </summary>	
        public string ModuleColumnId { get; set; }
        /// <summary>
        /// 功能主键
        /// </summary>		
        public string ModuleId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>		
        public string ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>		
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string FullName { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? SortCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Description { get; set; }
        #endregion

        
    }
}

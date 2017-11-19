 using Abp.Domain.Entities;

namespace Mao.Core.Authorize
{
    public partial class ModuleFormInstance : Entity
    {
        #region 实体成员
        /// <summary>
        /// 表单主键
        /// </summary>
        public string FormInstanceId { set; get; }
        /// <summary>
        /// 功能主键
        /// </summary>
        public string FormId { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FormInstanceJson { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ObjectId { set; get; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { set; get; }
        #endregion

        
    }
}



using Abp.Runtime.Validation;
using Mao.Application;



namespace Mao.Authorize.UserManager.Dtos
{
    /// <summary>
    /// 查询Dto
    /// </summary>
    public class GetUserInput : PagedAndSortedInputDto, IShouldNormalize
    {
		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string UserId { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "id";
            }
        }
    }
}

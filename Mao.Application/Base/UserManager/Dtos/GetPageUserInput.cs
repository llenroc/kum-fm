using Abp.Runtime.Validation;
using Mao.Application;



namespace Mao.Authorize.UserManager.Dtos
{
    /// <summary>
    /// 查询Dto
    /// </summary>
    public class GetPageUserInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "id";
            }
        }
    }
}

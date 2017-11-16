using Abp.Runtime.Validation;
using Mao.Application;



namespace Mao.Authorize.UserManager.Dtos
{
    /// <summary>
    /// 查询Dto
    /// </summary>
    public class GetUserInput 
    {
        public string UserId { get; set; }
    }
}

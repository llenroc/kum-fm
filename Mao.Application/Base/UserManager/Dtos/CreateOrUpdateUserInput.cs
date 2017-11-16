                            
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
 
namespace Mao.Authorize.UserManager.Dtos
{
    
    public class CreateOrUpdateUserInput
    {
    /// <summary>
    /// 编辑Dto
    /// </summary>
		public UserEditDto UserEditDto { get;set;}
 
    }
}

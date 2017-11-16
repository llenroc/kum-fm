
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;

namespace Mao.Authorize.UserManager.Dtos
{
    /// <summary>
    /// 用于添加或编辑 时使用的DTO
    /// </summary>

    public class GetUserForEditOutput
    {


        /// <summary>
        /// User编辑状态的DTO
        /// </summary>
        public UserEditDto User { get; set; }


    }
}

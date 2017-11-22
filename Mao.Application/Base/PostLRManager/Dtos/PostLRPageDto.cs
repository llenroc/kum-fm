
using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

using System.Collections.Generic;
using Mao;
using Mao.Core.Base;

namespace Mao.Application.Base.PostLRManager.Dtos
{
	/// <summary>
    /// 资质管理列表Dto
    /// </summary>
    public class PostLRPageDto : PagedAndSortedInputDto
    {
        public string EnCode { get; set; }


        public string FullName { get; set; }



    }
}

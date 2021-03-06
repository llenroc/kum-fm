﻿
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
    public class PostLRPageDto : ISortedResultRequest
    {
        public PostLRPageDto()
        {
            Sorting = "Id";
        }

        public string Sorting { get; set; }



        //[Range(1, MaoConsts.MaxPageSize)]
        //public int MaxResultCount { get; set; }
        public string EnCode { get; set; }


        public string FullName { get; set; }

        public int page { get; set; }


        public int total { get; set; }

        public int records { get; set; }




        //[Range(0, int.MaxValue)]
        //public int SkipCount { get; set; }


    }
}

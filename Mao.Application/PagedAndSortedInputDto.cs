using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao.Application
{
    public class PagedAndSortedInputDto : IPagedResultRequest, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = MaoConsts.DefaultPageSize;
        }

        [Range(1, MaoConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }


    }
}

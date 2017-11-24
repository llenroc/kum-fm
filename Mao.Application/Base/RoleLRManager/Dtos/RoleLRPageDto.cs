using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao.Application.Base.RoleLRManager.Dtos
{
    public class RoleLRPageDto : ISortedResultRequest
    {
        public RoleLRPageDto()
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

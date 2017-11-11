using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
  public  class Person:Entity
    {
        //[StringLength(50)]
        public string name { get; set; }
        //public int age { get; set; }

        //public bool sex { get; set; }

        //public Guid uid { get; set; }

        //public DateTime time { get; set; }



    }
}

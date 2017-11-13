using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao.Persons
{

  public partial class Person:FullAuditedEntity
    {

        public string name { get; set; }
        public int age { get; set; }

        public bool sex { get; set; }

        public DateTime time { get; set; }



    }
}

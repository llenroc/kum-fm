 // 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2017-09-07T14:52:32. All Rights Reserved.
//<生成时间>2017-09-07T14:52:32</生成时间>
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Mao.Persons;

namespace Mao.Persons.EntityMapper.Persons
{

	/// <summary>
    /// 人才啊的数据配置文件
    /// </summary>
    public class PersonCfg : EntityTypeConfiguration<Person>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "bjjdDbContext" /> ]
        /// </summary>
		public PersonCfg ()
		{
		            ToTable("Person", MaoConsts.SchemaName.Basic);
 
      //todo: 需要将以下文件注入到bjjdDbContext中

  //		public IDbSet<Person> Persons { get; set; }
   //		 modelBuilder.Configurations.Add(new PersonCfg());




		    // name
			Property(a => a.name).HasMaxLength(4000);
		}
    }
}
                            

using AutoMapper;

    #region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2017-09-25T13:03:31. All Rights Reserved.
//<生成时间>2017-09-25T13:03:31</生成时间>
	#endregion
namespace Mao.Application.Person.Mappers
{
	/// <summary>
    /// Wp_certificate_registrationDto映射配置
    /// </summary>
    public class PersonDtoMapper
    {

    private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();



        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
        
		  lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }

        }
    




	    /// <summary>
       ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(Wp_certificate_registrationDtoMapper.CreateMappings);
      ///注入位置    < see cref = "bjjdApplicationModule" /> 
     /// <param name="configuration"></param>
    /// </summary>       
	  private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
	  {
	           
			      //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

	  // Configuration.Modules.AbpAutoMapper().Configurators.Add(Wp_certificate_registrationDtoMapper.CreateMappings);

	    //    Mapper.CreateMap<Wp_certificate_registration,Wp_certificate_registrationEditDto>();
       //     Mapper.CreateMap<Wp_certificate_registration, Wp_certificate_registrationListDto>();

     //       Mapper.CreateMap<Wp_certificate_registrationEditDto, Wp_certificate_registration>();
    //        Mapper.CreateMap<Wp_certificate_registrationListDto,Wp_certificate_registration>();
  






 	  }


}}
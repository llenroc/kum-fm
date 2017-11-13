





using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Mao.Application.Person.Dtos;
using Mao.Persons;



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
// Copyright © YoYoCms@China.2017-09-25T13:03:30. All Rights Reserved.
//<生成时间>2017-09-25T13:03:30</生成时间>
#endregion


namespace Mao.Application.Person
{

    /// <summary>
    /// 资质管理服务实现
    /// </summary>

    public class PersonAppService : MaoAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Persons.Person, int> _personRepository;


        /// <summary>
        /// 构造方法
        /// </summary>
        public PersonAppService(
            IRepository<Persons.Person, int> personRepository
            )
        {
            _personRepository = personRepository;

        }

        public  IQueryable<Persons.Person> GetAll(GetPersonInput input)
        {
            return  _personRepository.GetAll();
        }


        public Task<PersonEditDto> BatchDeletePersonAsync(List<int> input)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PersonEditDto> CreatePersonAsync(PersonEditDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }



        public Task<PagedResultDto<object>> GetCertificateAndUserAsync(GetPersonInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PersonListDto>> GetCertificateAsync(GetPersonInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PersonListDto>> GetPagedPersonsAsync(GetPersonInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PersonListDto> GetPersonByIdAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonAsync(PersonEditDto input)
        {
            throw new NotImplementedException();
        }

       

        Task IPersonAppService.BatchDeletePersonAsync(List<int> input)
        {
            throw new NotImplementedException();
        }
    }
}

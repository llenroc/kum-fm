using System.Threading.Tasks;
//using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Mao.Application.Person.Dtos;
using System.Linq;
using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using System.Data.Entity;


//using MyCompanyName.AbpZeroTemplate.Authorization;
//using MyCompanyName.AbpZeroTemplate.Authorization.Users;
//using MyCompanyName.AbpZeroTemplate.MultiTenancy;
//using MyCompanyName.AbpZeroTemplate.WebApi.Models;

namespace Mao.WebApi.Controllers
{
    public class PersonsController : MaoApiControllerBase
    {
        //public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly IRepository<Persons.Person> _personRepository;
        //private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;

        //static AccountController()
        //{
        //    OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        //}

        public PersonsController(
        IRepository<Persons.Person> personRepository
            )
        {
            _personRepository = personRepository;
            //    _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            //    _logInManager = logInManager;
        }

        public async Task<PagedResultDto<PersonListDto>> GetAllAsync(GetPersonInput input)
        {
            var query = _personRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var personCount = await query.CountAsync();

            var persons = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var personListDtos = persons.MapTo<List<PersonListDto>>();


            return new PagedResultDto<PersonListDto>(
            personCount,
            personListDtos
            );
        }

        //[HttpPost]
        //public async Task<AjaxResponse> Authenticate(LoginModel loginModel)
        //{
        //    var loginResult = await GetLoginResultAsync(
        //        loginModel.UsernameOrEmailAddress,
        //        loginModel.Password,
        //        loginModel.TenancyName
        //        );

        //    var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());

        //    var currentUtc = new SystemClock().UtcNow;
        //    ticket.Properties.IssuedUtc = currentUtc;
        //    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

        //    return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
        //}

        //private object GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        //{
        //    //var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

        //    //switch (loginResult.Result)
        //    //{
        //    //    case AbpLoginResultType.Success:
        //    //        return loginResult;
        //    //    default:
        //    //        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
        //    //}
        //    return null;
        //}
    }
}

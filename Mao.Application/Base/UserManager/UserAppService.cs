
using System.Collections.Generic;
using System.Data;

using System.Linq;

using Mao;
using Mao.Core.Base;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Mao.Authorize.UserManager.Dtos;
using Abp.AutoMapper;
using System.Data.Entity;
using System.Linq.Dynamic.Core;
using System;
using System.Linq.Expressions;

namespace Mao.Application.Base.UserManager
{

    public class UserAppService : MaoAppServiceBase, IUserAppService
    {
        //private readonly UserService _userRepository;
        private readonly IRepository<User, int> _userRepository;

        public UserAppService(
            IRepository<User, int> userRepository
            )
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 根据查询条件获取分页列表
        /// </summary>
        public async Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetPageUserInput input)
        {
            var userList = new List<User>();
            var query = _userRepository.GetAll();
            int UserCount = await query.CountAsync();
            //TODO:根据传入的参数添加过滤条件

            userList = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();


            var UserListDtos = userList.MapTo<List<UserListDto>>();



            return new PagedResultDto<UserListDto>(
            UserCount,
            UserListDtos
            );

        }


        /// <summary>
        /// 通过指定id获取ListDto信息
        /// </summary>
        public async Task<User> GetUsersAsync(GetUserInput input)
        {

            var entity =await _userRepository.FirstOrDefaultAsync(a => a.UserId == input.UserId);

            return entity.MapTo<User>();
        }
        /// <summary>
        /// 新增或更改-不传userid是新增,传了是修改
        /// </summary>
        public async Task<UserEditDto> CreateOrUpdateUserAsync(CreateOrUpdateUserInput input)
        {
            

            if (!string.IsNullOrEmpty(input.UserEditDto.UserId))
            {
                return await UpdateUserAsync(input.UserEditDto);
            }
            else
            {
                input.UserEditDto.UserId = Guid.NewGuid().ToString();
                return await CreateUserAsync(input.UserEditDto);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>

        public virtual async Task<UserEditDto> CreateUserAsync(UserEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<User>();
            entity = await _userRepository.InsertAsync(entity);
            return entity.MapTo<UserEditDto>();
        }

        /// <summary>
        /// 编辑
        /// </summary>

        public virtual async Task<UserEditDto> UpdateUserAsync(UserEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _userRepository.GetAsync(a => a.UserId == input.UserId);
            input.MapTo(entity);
            entity = await _userRepository.UpdateAsync(entity);
            return entity.MapTo<UserEditDto>();
        }

        /// <summary>
        /// 删除
        /// </summary>

        public async Task DeleteUserAsync(GetUserInput input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _userRepository.DeleteAsync(a => a.UserId == input.UserId);
        }

        /// <summary>
        /// 批量删除
        /// </summary>

        public async Task BatchDeleteUserAsync(List<string> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _userRepository.DeleteAsync(s => input.Contains(s.UserId));
        }

        

      
    }



   
}

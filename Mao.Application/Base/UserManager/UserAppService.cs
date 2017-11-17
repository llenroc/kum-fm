
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
using Abp.Dependency;
using Mao.Extensions;
using Mao.Util.Extension;
using Mao.Application.Authorize;
using Mao.Base.UserManager.Dtos;

namespace Mao.Application.Base.UserManager
{

    public class UserAppService : MaoAppServiceBase, IUserAppService
    {
        //private readonly UserService _userRepository;
        private readonly IRepository<User, int> _userRepository;
        private readonly ISqlExecuter _sqlExecuter;

        public UserAppService(
            IRepository<User, int> userRepository
            //ISqlExecuter sqlExecuter
            )
        {
            _userRepository = userRepository;
            //值得注意的是，调用代码需要工作单元的支持，Application中已默认支持，可直接使用。但如果在Controller中使用就需要将Action设置为UnitOfWork(不知道从哪个版本开始，Controller也默认支持工作单元了)

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;
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

            var entity = await _userRepository.FirstOrDefaultAsync(a => a.UserId == input.UserId);

            return entity.MapTo<User>();
        }
        /// <summary>
        /// 新增或更改-不传userid是新增,传了是修改
        /// </summary>
        public async Task<UserEditDto> CreateOrUpdateUserAsync(CreateOrUpdateUserInput input)
        {


            if (input.UserEditDto.UserId > 0)
            {
                return await UpdateUserAsync(input.UserEditDto);
            }
            else
            {
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

            var entity = await _userRepository.GetAsync(input.UserId);
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


        //        public async Task<IEnumerable<User>> TestSql(string UserId)
        //        {
        //            string whereClause = string.Empty;
        //            //if (operatorId > 0)
        //            //{
        //            //    whereClause += string.Format(" where Id={0} ", operatorId);
        //            //}
        //            string sql = string.Format(@"
        //SELECT ROW_NUMBER() OVER(ORDER BY Id )AS RowId,Id,Name,AllocateRatio,
        //(SELECT SUM(PayFee) FROM dbo.Orders WHERE Status NOT IN(0,3,4) AND OperatorID=dbo.Operators.Id AND YEAR(OrderDate)=@Year3) AS TotalScanCode,
        //(SELECT SUM(TheDayMoney) FROM dbo.DeviceCoinsRecords WHERE dbo.DeviceCoinsRecords.OperatorID=dbo.Operators.Id AND Year=@Year4) AS TotalCoinsCast
        // FROM dbo.Operators {0}", whereClause);

        //            return await Context.Database.SqlQuery<OperatorYearOrMonthReport>(sql,
        //                new SqlParameter("@Year3", year),
        //                new SqlParameter("@Year4", year)).ToListAsync();

        //        }
        public async Task<List<UserListDto>> TestSqlAsync()
        {
            const string sql = "select * from users";
            var user = await _sqlExecuter.SqlQueryAsync<UserListDto>(sql);
            return user;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public UserEditDto CheckLogin(string username)
        {
            var expression = LinqExtensions.True<User>();
            expression = expression.And(t => t.Account == username);
            expression = expression.Or(t => t.Mobile == username);
            expression = expression.Or(t => t.Email == username);

            var user = _userRepository.FirstOrDefault(expression);

            return user.MapTo<UserEditDto>();
        }



        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        //public async Task<LoginResult> CheckLoginAsync(string username, string password)
        //{
        //    UserEditDto userEntity = CheckLogin(username);
        //    if (userEntity != null)
        //    {
        //        if (userEntity.EnabledMark == 1)
        //        {
        //            string dbPassword = Md5Helper.MD5(DESEncrypt.Encrypt(password.ToLower(), userEntity.Secretkey).ToLower(), 32).ToLower();
        //            if (dbPassword == userEntity.Password)
        //            {
        //                DateTime LastVisit = DateTime.Now;
        //                int LogOnCount = (userEntity.LogOnCount).ToInt() + 1;
        //                if (userEntity.LastVisit != null)
        //                {
        //                    userEntity.PreviousVisit = userEntity.LastVisit.ToDate();
        //                }
        //                userEntity.LastVisit = LastVisit;
        //                userEntity.LogOnCount = LogOnCount;
        //                userEntity.UserOnLine = 1;
        //                await UpdateUserAsync(userEntity);
        //                return new LoginResult(MaoLoginResultType.Success, userEntity.Id);
        //            }
        //            else
        //            {

        //                return new LoginResult(MaoLoginResultType.InvalidPassword, userEntity.UserId);
        //            }
        //        }
        //        else
        //        {
        //            return new LoginResult(MaoLoginResultType.LockedOut, userEntity.UserId);
        //        }
        //    }
        //    else
        //    {
        //        return new LoginResult(MaoLoginResultType.InvalidPassword, userEntity.UserId);
        //    }
        //}


        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="Password">新密码（MD5 小写）</param>
        //public async Task RevisePasswordAsync(string UserId, string Password)
        //{
        //    UserEditDto userEntity = new UserEditDto();
        //    userEntity.UserId = UserId;
        //    userEntity.Secretkey = Md5Helper.MD5(CommonHelper.CreateNo(), 16).ToLower();
        //    userEntity.Password = Md5Helper.MD5(DESEncrypt.Encrypt(Password, userEntity.Secretkey).ToLower(), 32).ToLower();
        //    await UpdateUserAsync(userEntity);
        //}



    }




}

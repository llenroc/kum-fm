using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Zero.Configuration;
using Microsoft.AspNet.Identity;
using Mao.Application.Authorization.Permissions;
using Mao.Application.Authorization.Permissions.Dto;
using Mao.Application.Authorization.Roles;
using Mao.Application.Authorization.Users.Dto;
using Mao.Application.Authorization.Users.Exporting;
using Mao.Application.Dto;
using Mao.Application.Notifications;
using Mao.Core.Authorization;
using Mao.Core.Authorization.Users;
using Mao.Core.Notifications;
using Mao.Core.Authorization.Roles;
using Abp.Web.Models;
using Mao.Util.Extension;
using Mao.Application.Base.UserGroupManager.Dtos;
using Mao.Application.Base;
using Mao.Core.Base;

namespace Mao.Application.Authorization.Users
{
    //[AbpAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UserAppService : MaoAppServiceBase, IUserAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IUserEmailer _userEmailer;
        //private readonly IUserListExcelExporter _userListExcelExporter;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly IAppNotifier _appNotifier;
        private readonly IRepository<RolePermissionSetting, long> _rolePermissionRepository;
        private readonly IRepository<UserPermissionSetting, long> _userPermissionRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IUserPolicy _userPolicy;



        private IRepository<RoleLR> _roleLR;
        private IRepository<Department> _department;
        private IRepository<Organize> _organize;





            public UserAppService(
            RoleManager roleManager,
            IUserEmailer userEmailer,
            IUserListExcelExporter userListExcelExporter,
            INotificationSubscriptionManager notificationSubscriptionManager,
            IAppNotifier appNotifier,
            IRepository<RolePermissionSetting, long> rolePermissionRepository,
            IRepository<UserPermissionSetting, long> userPermissionRepository,
            IRepository<UserRole, long> userRoleRepository,
              IRepository<RoleLR> roleLR,
             IRepository<Department> department,
              IRepository<Organize> organize,
            IUserPolicy userPolicy)
        {
            _roleManager = roleManager;
            _userEmailer = userEmailer;
            //_userListExcelExporter = userListExcelExporter;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _appNotifier = appNotifier;
            _rolePermissionRepository = rolePermissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _userPolicy = userPolicy;

            _department = department;
            _organize = organize;
            _roleLR = roleLR;
        }

  



        #region 获取数据
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>返回机构+部门+用户树形Json</returns>
        [DontWrapResult]
        public object GetTreeJson(GetUsersInput input)
        {


            var query = UserManager.Users.ToList();
            //.Include(u => u.Roles)
            //.WhereIf(input.Role.HasValue, u => u.Roles.Any(r => r.RoleId == input.Role.Value))
            //.WhereIf(
            //    !input.Filter.IsNullOrWhiteSpace(),
            //    u =>
            //        //u.Name.Contains(input.Filter) ||
            //        //u.Surname.Contains(input.Filter) ||
            //        u.UserName.Contains(input.Filter) ||
            //        u.EmailAddress.Contains(input.Filter)
            //);



            //var userCount = await query.CountAsync();
            //var users = await query
            //    .OrderBy(input.Sorting)
            //    .PageBy(input)
            //    .ToListAsync();



            var organizedata = _organize.GetAll();
            var departmentdata = _department.GetAll();
            var userdata = query;
            var treeList = new List<TreeEntity>();
            foreach (Organize item in organizedata)
            {
                #region 机构
                TreeEntity tree = new TreeEntity();
                bool hasChildren = organizedata.Count(t => t.ParentId == item.OrganizeId) == 0 ? false : true;
                if (hasChildren == false)
                {
                    hasChildren = departmentdata.Count(t => t.OrganizeId == item.OrganizeId) == 0 ? false : true;
                    if (hasChildren == false)
                    {
                        continue;
                    }
                }
                tree.id = item.OrganizeId;
                tree.text = item.FullName;
                tree.value = item.OrganizeId;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Organize";
                treeList.Add(tree);
                #endregion
            }
            foreach (Department item in departmentdata)
            {
                #region 部门
                TreeEntity tree = new TreeEntity();
                tree.id = item.DepartmentId;
                tree.text = item.FullName;
                tree.value = item.DepartmentId;
                if (item.ParentId == "0")
                {
                    tree.parentId = item.OrganizeId;
                }
                else
                {
                    tree.parentId = item.ParentId;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = true;
                tree.Attribute = "Sort";
                tree.AttributeValue = "Department";
                treeList.Add(tree);
                #endregion
            }
            foreach (User item in userdata)
            {
                #region 用户
                TreeEntity tree = new TreeEntity();
                tree.id = item.Id.ToString();
                tree.text = item.RealName;
                tree.value = item.UserName;
                tree.parentId = item.DepartmentId;
                tree.title = item.RealName + "（" + item.RealName + "）";
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = false;
                tree.Attribute = "Sort";
                tree.AttributeValue = "User";
                tree.img = "fa fa-user";
                treeList.Add(tree);
                #endregion
            }
            //if (!string.IsNullOrEmpty(input.Filter))
            //{
            //    treeList = treeList.TreeWhere(t => t.text.Contains(input.Filter), "id", "parentId");
            //}
            return Newtonsoft.Json.JsonConvert.DeserializeObject(treeList.TreeToJson());
        }
        ///// <summary>
        ///// 用户列表
        ///// </summary>
        ///// <param name="departmentId">部门Id</param>
        ///// <returns>返回用户列表Json</returns>

        //public object GetListJson(string departmentId)
        //{
        //    var data = userCache.GetList(departmentId);
        //    return Content(data.ToJson());
        //}
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [DontWrapResult]
        public async Task<object> GetPageListJson(UserGroupLRPageDto input)
        {
            var watch = CommonHelper.TimerStart();
            var query = UserManager.Users;


            int records = 0;
            int total = 0;
            var data =await query.OrderBy(input.Sorting).PageBy(MaoConsts.DefaultPageSize, input.page, out records, out total).ToListAsync();
           
            //var userListDtos = data.MapTo<List<UserListDto>>();

            var JsonData = new
            {
                rows = data,
                total = total,
                page = input.page,
                records = records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return Newtonsoft.Json.JsonConvert.DeserializeObject(JsonData.ToJson());
        }
        /// <summary>
        /// 用户实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [DontWrapResult]
        public object GetFormJson(long keyValue)
        {
            var data = UserManager.Users.FirstOrDefault(a => a.Id == keyValue);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data.ToJson());
        }

        public Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input)
        {
            throw new System.NotImplementedException();
        }

        public Task<FileDto> GetUsersToExcel()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}

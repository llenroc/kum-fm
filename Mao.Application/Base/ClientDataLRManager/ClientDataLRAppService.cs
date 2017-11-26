using Abp.Dependency;
using Abp.Domain.Repositories;
using Mao.Application;
using Mao.Application.Authorize.AuthorizeManager;
using Mao.Application.Authorize.ModuleButtonManager;
using Mao.Application.Authorize.ModuleColumnManager;
using Mao.Core.Authorization.Users;
using Mao.Core.Base;
using Mao.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mao.Base;
using Mao.Application.Base.UserGroupManager;
using Mao.Application.Base.RoleLRManager;
using Abp.Runtime.Session;
using Mao.Application.Base.DepartmentManager;
using Mao.Application.Base.OrganizeManager;
using Mao.Core.Authorize;
using Mao.Util.Extension;

namespace Mao.Base.ClientDataLRManager
{


    public class ClientDataLRAppService : MaoAppServiceBase, IClientDataLRAppService
    {

        private DepartmentLRAppService _department;
        private OrganizeLRAppService _organize;
        private RoleLRAppService _roleLR;

        private readonly ISqlExecuter _sqlExecuter;

        private AuthorizeAppService _authorize;
        private ModuleButtonAppService _moduleButton;
        private ModuleColumnAppService _moduleColumn;
        private UserGroupLRAppService _userGroup;
        private PostLRAppService _post;

        public IAbpSession AbpSession { get; set; }

        public ClientDataLRAppService(
             DepartmentLRAppService department,
              OrganizeLRAppService organize,
                RoleLRAppService roleLR,
                  AuthorizeAppService authorize,
                  ModuleButtonAppService moduleButton,
                  ModuleColumnAppService moduleColumn,
                  UserGroupLRAppService userGroup,
            PostLRAppService post

            )
        {
            _authorize = authorize;
            _department = department;
            _roleLR = roleLR;
            _organize = organize;
            _moduleButton = moduleButton;
            _moduleColumn = moduleColumn;
            _userGroup = userGroup;
            _post = post;

            AbpSession = NullAbpSession.Instance;

            var currentUserId = AbpSession.UserId;

            var sqlExecuter = IocManager.Instance.Resolve<ISqlExecuter>();
            _sqlExecuter = sqlExecuter;

        }

        #region 获取数据
        /// <summary>
        /// 批量加载数据给客户端（把常用数据全部加载到浏览器中 这样能够减少数据库交互）
        /// </summary>
        /// <returns></returns>
        public object GetClientDataJson()
        {
            //var jsonData = new
            //{
            var organize = GetOrganizeData();
            var department = GetDepartmentData();         //部门
            var post               = GetPostData();                    //岗位
            var role                 = GetRoleData();                           //角色
            var userGroup           = GetUserGroupData();           //dataItem = this.GetDataItem(),                  //字典
            var authorizeMenu     = _authorize.GetModuleList();           //导航菜单

            var authorizeButton = _authorize.GetModuleButtonList(); //功能按钮

            var authorizeColumn = _authorize.GetModuleColumnList();//功能视图

            var jsonData = new {
             organize         = organize,
             department       = department    , 
             post             = post           ,
             role             = role           ,
             userGroup        = userGroup      ,
             authorizeMenu    = authorizeMenu  ,
             authorizeButton  = authorizeButton,
             authorizeColumn = authorizeColumn

            };


            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
        }
        #endregion



        #region 处理基础数据
        /// <summary>
        /// 获取公司数据
        /// </summary>
        /// <returns></returns>
        private object GetOrganizeData()
        {
            var data = _organize.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Organize item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.OrganizeId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取部门数据
        /// </summary>
        /// <returns></returns>
        private object GetDepartmentData()
        {
            var data = _department.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Department item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName,
                    OrganizeId = item.OrganizeId
                };
                dictionary.Add(item.DepartmentId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private object GetUserGroupData()
        {
            var data = _userGroup.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleLR item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private object GetPostData()
        {
            var data = _post.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleLR item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        private object GetRoleData()
        {
            var data = _roleLR.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleLR item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.RoleId, fieldItem);
            }
            return dictionary;
        }
       
        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <returns></returns>
        //private object GetDataItem()
        //{
        //    var dataList = dataItemCache.GetDataItemList();
        //    var dataSort = dataList.Distinct(new Comparint<DataItemModel>("EnCode"));
        //    Dictionary<string, object> dictionarySort = new Dictionary<string, object>();
        //    foreach (DataItemModel itemSort in dataSort)
        //    {
        //        var dataItemList = dataList.Where(t => t.EnCode.Equals(itemSort.EnCode));
        //        Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
        //        foreach (DataItemModel itemList in dataItemList)
        //        {
        //            dictionaryItemList.Add(itemList.ItemValue, itemList.ItemName);
        //        }
        //        foreach (DataItemModel itemList in dataItemList)
        //        {
        //            dictionaryItemList.Add(itemList.ItemDetailId, itemList.ItemName);
        //        }
        //        dictionarySort.Add(itemSort.EnCode, dictionaryItemList);
        //    }
        //    return dictionarySort;
        //}
        #endregion
    }



}

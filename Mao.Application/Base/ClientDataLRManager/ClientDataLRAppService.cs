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

namespace Mao.Base.ClientDataLRManager
{


    public class ClientDataLRAppService : MaoAppServiceBase, IClientDataLRAppService
    {

        private DepartmentLRAppService _department;
        private OrganizeLRAppService _organize;
        private RoleLRService _roleLR;

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
                RoleLRService roleLR,
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
            var organize           = _organize.GetList();
            var department         = _department.GetList();          //部门
            var post               = _post.GetAllList();                    //岗位
            var role                 = _roleLR.GetAllList();                           //角色
            var userGroup           = _userGroup.GetAllList();           //dataItem = this.GetDataItem(),                  //字典
            var authorizeMenu     = _authorize.GetModuleList(AbpSession.UserId.ToString());           //导航菜单
            var authorizeButton = _moduleButton.GetList();   //功能按钮
            var authorizeColumn = _moduleColumn.GetList();    //功能视图
                                                              // };

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
    }



}

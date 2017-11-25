
using Mao.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Mao.Web.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.1 1:35
    /// 描 述：用户组权限
    /// </summary>
    public class PermissionUserGroupController : MaoControllerBase
    {


        #region 视图功能
        /// <summary>
        /// 用户组权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult AllotAuthorize()
        {
            return View();
        }
        /// <summary>
        /// 用户组成员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult AllotMember()
        {
            return View();
        }
        #endregion

    }
}

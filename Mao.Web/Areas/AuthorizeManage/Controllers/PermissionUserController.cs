﻿
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
    /// 日 期：2015.11.2 2:35
    /// 描 述：用户权限
    /// </summary>
    public class PermissionUserController : MaoControllerBase
    {
      

        #region 视图功能
        /// <summary>
        /// 用户权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult AllotAuthorize()
        {
            return View();
        }
        #endregion


    }
}

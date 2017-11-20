
using Mao.Web.Controllers;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：角色管理
    /// </summary>
    public class RoleController : MaoControllerBase
    {


        #region 视图功能
        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 角色表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public ActionResult Form()
        {
            return View();
        }
        #endregion
    }
     
}

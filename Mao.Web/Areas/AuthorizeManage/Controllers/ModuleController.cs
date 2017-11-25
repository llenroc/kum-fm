
using Mao.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mao.Web.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class ModuleController : MaoControllerBase
    {
       

        #region 视图功能
        /// <summary>
        /// 功能管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 功能表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult Form()
        {
            ViewBag.ModuleId = Request["keyValue"];
            return View();
        }
        /// <summary>
        /// 功能图标
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Icon()
        {
            return View();
        }
        #endregion


    }
}

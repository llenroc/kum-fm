
using Mao.Web.Controllers;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.Application.Web.Controllers
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.03 10:58
    /// 描 述：个人中心
    /// </summary>
    public class PersonCenterController : MaoControllerBase
    {
       

        #region 视图功能
        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            //ViewBag.userId = OperatorProvider.Provider.Current().UserId;
            return View();
        }
        #endregion


    }
}

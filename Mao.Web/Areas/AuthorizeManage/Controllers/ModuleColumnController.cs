
using Mao.Web.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Mao.Web.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnController : MaoControllerBase
    {
     

        #region 视图功能
        /// <summary>
        /// 视图表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BatchAdd()
        {
            return View();
        }
        #endregion


    }
}

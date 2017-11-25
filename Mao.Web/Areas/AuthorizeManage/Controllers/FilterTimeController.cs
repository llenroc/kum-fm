
using Mao.Web.Controllers;
using System.Web.Mvc;

namespace Mao.Web.Areas.AuthorizeManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤时段
    /// </summary>
    public class FilterTimeController : MaoControllerBase
    {
      

        #region 视图功能
        /// <summary>
        /// 过滤时段管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 过滤时段表单
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

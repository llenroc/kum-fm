
using Mao.Web.Controllers;
using System.Web.Mvc;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.11.4 14:31
    /// 描 述：职位管理
    /// </summary>
    public class JobController : MaoControllerBase
    {
      
        #region 视图功能
        /// <summary>
        /// 职位管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 职位表单
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

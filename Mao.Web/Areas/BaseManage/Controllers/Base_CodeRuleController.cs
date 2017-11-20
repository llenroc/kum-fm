
using System.Web.Mvc;
using Mao.Web.Controllers;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-07-28 21:24
    /// 描 述：编号规则表
    /// </summary>
    public class Base_CodeRuleController : MaoControllerBase
    {


        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_CodeRuleIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_CodeRuleForm()
        {
            return View();
        }
        #endregion


    }
}

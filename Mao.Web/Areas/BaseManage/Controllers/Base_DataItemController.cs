
using System.Web.Mvc;
using Mao.Web.Controllers;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-07-26 22:23
    /// 描 述：数据字典分类表
    /// </summary>
    public class Base_DataItemController : MaoControllerBase
    {
        

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_DataItemIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_DataItemForm()
        {
            return View();
        }
        #endregion


    }
}

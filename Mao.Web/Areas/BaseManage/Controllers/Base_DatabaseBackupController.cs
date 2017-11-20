
using Mao.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-07-31 20:50
    /// 描 述：数据库备份
    /// </summary>
    public class Base_DatabaseBackupController : MaoControllerBase
    {
       

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_DatabaseBackupIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_DatabaseBackupForm()
        {
            return View();
        }
        #endregion

    }
}

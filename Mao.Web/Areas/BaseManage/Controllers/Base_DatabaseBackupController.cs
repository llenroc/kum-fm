
using Mao.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-07-31 20:50
    /// �� �������ݿⱸ��
    /// </summary>
    public class Base_DatabaseBackupController : MaoControllerBase
    {
       

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_DatabaseBackupIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
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

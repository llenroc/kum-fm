
using System.Web.Mvc;
using Mao.Web.Controllers;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-07-26 22:35
    /// �� �����û���Ϣ��
    /// </summary>
    public class Base_UserController : MaoControllerBase
    {
       

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_UserIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_UserForm()
        {
            return View();
        }
        #endregion

    }
}

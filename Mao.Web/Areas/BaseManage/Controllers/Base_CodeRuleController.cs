
using System.Web.Mvc;
using Mao.Web.Controllers;

namespace Mao.Web.Areas.BaseManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-07-28 21:24
    /// �� ������Ź����
    /// </summary>
    public class Base_CodeRuleController : MaoControllerBase
    {


        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Base_CodeRuleIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
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

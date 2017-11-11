using System.Web.Mvc;

namespace Mao.Web.Controllers
{
    public class AboutController : MaoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
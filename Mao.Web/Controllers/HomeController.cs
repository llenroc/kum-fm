using System.Web.Mvc;

namespace Mao.Web.Controllers
{
    public class HomeController : MaoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
using System.Web.Mvc;

namespace Nekram.App.Controllers {
    public class HomeController : Controller {
        
        public ActionResult Index() {
            return View();
        }
    }
}
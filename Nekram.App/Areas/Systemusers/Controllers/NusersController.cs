using System.Web.Mvc;
using Nekram.App.Controllers;

namespace Nekram.App.Areas.Systemusers.Controllers
{
    public class NusersController : BaseController
    {
        // GET: Systemusers/Nusers
        public ActionResult Index()
        {
            return View();
        }
    }
}
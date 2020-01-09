using System.Web.Mvc;
using Nekram.App.Controllers;

namespace Nekram.App.Areas.Branches.Controllers
{
    public class CompanyhomeController : BaseController
    {
        // GET: Branches/Companyhome
        public ActionResult Index()
        {
            return View();
        }
    }
}
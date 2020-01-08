using System.Web.Mvc;
using Nekram.Infrastructure;
using Nekram.Models.RepositoryInterfaces;

namespace Nekram.App.Controllers {
    public class HomeController : Controller {

        private readonly IBranchRepository branchrepo;
        private readonly IUnitOfWork _uow;

        public ActionResult Index() {
            return View();
        }
    }
}
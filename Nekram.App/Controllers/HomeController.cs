using System.Linq;
using System.Web.Mvc;
using Nekram.Models.Collections;
using Nekram.Models.RepositoryInterfaces;
using Nekram.Repositories.Application;

// ReSharper disable TooWideLocalVariableScope

namespace Nekram.App.Controllers {

    public class HomeController : Controller {

        private readonly IBranchRepository _repository;

        public HomeController():this(new BranchRepositories()){ }

        public HomeController(IBranchRepository repository) {
            _repository = repository;
        }

        public ActionResult Index()  {

            string error;
            Branches branches = null;

            var list = _repository.FindAll(out error).ToList();

            if (list.Any()) {
                branches = new Branches();
                list.ForEach(branches.Add);
            }

            if (!string.IsNullOrWhiteSpace(error)) {
                ModelState.AddModelError("", error);
            }

            return View(branches);
        }
    }
}
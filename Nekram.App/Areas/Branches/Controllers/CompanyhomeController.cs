using System.Linq;
using System.Web.Mvc;
using Nekram.App.Areas.Branches.ViewModels;
using Nekram.App.Controllers;
using Nekram.Infrastructure;
using Nekram.Models.RepositoryInterfaces;
using Nekram.Repositories.Application;

namespace Nekram.App.Areas.Branches.Controllers {
    public class CompanyhomeController : BaseController {

        private readonly IBranchRepository _repository;

        public CompanyhomeController()
            : this(new BranchRepositories()) {          
        }

        public CompanyhomeController(IBranchRepository repository) {
            _repository = repository;
        }

        public ActionResult Index() {
            string error;
            Models.Collections.Branches branches = null;

            var list = _repository.FindAll(out error).ToList();

            if (list.Any()) {
                branches = new Models.Collections.Branches();
                list.ForEach(branches.Add);
            }

            if (!string.IsNullOrWhiteSpace(error)) {
                ModelState.AddModelError("", error);
            }

            return View(branches);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BranchViewModel model) {

            if (ModelState.IsValid) {

                try {
                } catch (ModelValidationException mex) {

                    foreach (var error in mex.ValidationErrors) {
                        ModelState.AddModelError(
                            error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage);
                    }

                }
            }

            return View(model);
        }
    }
}
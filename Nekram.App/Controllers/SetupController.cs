
using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Nekram.App.Helpers;
using Nekram.App.ViewModels;
using Nekram.Infrastructure;
using Nekram.Models.Application;
using Nekram.Models.RepositoryInterfaces;

namespace Nekram.App.Controllers {
    public class SetupController : BaseController {
        private readonly IBranchRepository _brepo;
        private readonly IUnitOfWorkFactory _uowf;

        /// <summary>
        /// Initializes a new instance of the PeopleController class.
        /// </summary>
        public SetupController(IBranchRepository branchRepository, IUnitOfWorkFactory uowf) {
            _brepo = branchRepository;
            _uowf = uowf;
        }

        [HttpGet]
        public ActionResult Setup() {
            return View();
        }

        [HttpPost]
        public ActionResult CompanyInfo() {
            var email = Request["companymail"];

            if (string.IsNullOrEmpty(email))
                ModelState.AddModelError("Email", "Please enter your company email address.");

            if (ModelState.IsValid) {
                SessionManager.Set(SessionKeys.Email, email);
                return View("Complete");
            }

            return View("Setup");
        }

        [HttpPost]
        public ActionResult Complete(SetupViewModel model) {

            if (ModelState.IsValid) {

                try {

                    using (_uowf.Create()) {

                        var companymail = SessionManager.Get<string>(SessionKeys.Email);
                        model.Email = companymail;

                        var company = new Branch {
                            Mobil = string.Empty,
                            Logo = string.Empty,
                            Website = string.Empty,
                            Country = string.Empty,
                            IsMain = true,
                            Created = DateTime.Now,
                            Modified = DateTime.Now
                        };

                        //map company to view model
                        Mapper.Map(model, company);

                        string error;
                        _brepo.Add(company, out error);
                        Error = error;

                        if (string.IsNullOrEmpty(Error)) {
                            SessionManager.Set(SessionKeys.Company, company);
                            return RedirectToAction("Index", "Home");
                        }

                        ModelState.AddModelError("", Error);
                    }

                } catch (ModelValidationException mex) {

                    //catch model related exceptions
                    foreach (var error in mex.ValidationErrors) {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage);
                    }
                }
                
            }

            return View();
        }

    }
}
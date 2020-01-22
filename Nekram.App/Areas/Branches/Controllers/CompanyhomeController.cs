using System;
using System.IO;
using System.Linq;
using System.Web.Helpers;
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

            Models.Collections.Branches branches = null;

            try {
                string error;
                var list = _repository.FindAll(out error).ToList();

                if (list.Any()) {
                    branches = new Models.Collections.Branches();
                    list.ForEach(branches.Add);
                }

                if (!string.IsNullOrWhiteSpace(error)) {
                    ModelState.AddModelError("", error);
                }

            } catch (ModelValidationException mex) {

                foreach (var error in mex.ValidationErrors) {
                    ModelState.AddModelError(
                        error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage);
                }

            }
            
            return View(branches);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetLogofile() {

            var imgname = string.Empty;

            try {

                if (Request.Files.AllKeys.Any()) {
                    var img = Request.Files["companylogo"];

                    if (img != null && img.ContentLength > 0) {
                        var filename = Path.GetFileName(img.FileName);
                        var ext = Path.GetExtension(img.FileName);
                        string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };

                        if (allowedFileTypes.Contains(ext)) {

                            if (img.ContentLength < 2097152) {

                                imgname = Guid.NewGuid().ToString();
                                var commonpath = $"{Server.MapPath(AppConstants.LogoPath)}\\{filename}";
                                imgname = $"{imgname}{ext}";
                                var thumbpath = $"{Server.MapPath(AppConstants.LogoThumbnailPath)}\\{imgname}";

                                Session["companylogo"] = filename;

                                //resize image
                                var logo = new WebImage(img.InputStream);

                                if (logo.Width > 190) {
                                    logo.Resize(190, logo.Height);
                                }

                                logo.Save(commonpath);

                                if (logo.Width > 100) {
                                    logo.Resize(100, logo.Height);
                                }

                                logo.Save(thumbpath);

                            } else {
                                ModelState.AddModelError("", "Image size is too big.");
                            }
                        } else {
                            ModelState.AddModelError("", "Pleasel load a valid image file(gif,png,jpeg).");
                        }
                    }
                }

            } catch (ModelValidationException mex) {

                foreach (var error in mex.ValidationErrors) {
                    ModelState.AddModelError(
                        error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage);
                }

            }

            return Json(Convert.ToString(imgname), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
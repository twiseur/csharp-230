using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenterBusiness;
using LearningCenterWebApp.Repositories;
using LearningCenterWebApp.Models;
using System.Web.Security;

namespace LearningCenterWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserManager userManager;
        private readonly IClassManager classManager;

        public HomeController()
        {
        }

        public HomeController(IUserManager userManager, IClassManager classManager)
        {
            this.userManager = userManager;
            this.classManager = classManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClassList()
        {
            return View(classManager.Classes);
        }

        [Authorize]
        public ActionResult StudentClasses()
        {
            int userId = ((User)Session["User"]).UserId;

            var classes = classManager.UserClasses(userId);

            return View(classes);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EnrollInClass()
        {
            var allClasses = classManager.Classes;
            var currentUserClasses = classManager.UserClasses(((User)Session["User"]).UserId);

            var remainingClasses = allClasses.Where(c => !currentUserClasses.Any(c2 => c2.ClassId == c.ClassId)).ToList();

            List<SelectListItem> availableClasses = new List<SelectListItem>();
            foreach (var tmpClass in remainingClasses)
            {
                availableClasses.Add(new SelectListItem { Selected = false, Text = tmpClass.ClassName, Value = tmpClass.ClassId.ToString() });
            }


            var addClassResponse = new LearningCenterWebApp.Models.AddClassResponse { AvailableClasses = availableClasses, ClassAdded = null };

            return View(addClassResponse);
        }

        [HttpPost]
        public ActionResult EnrollInClass(AddClassResponse addClassResponse)
        {
            int userId = ((User)Session["User"]).UserId;
            int classId = int.Parse(addClassResponse.ClassAdded);

            classManager.Add(classId, userId);

            return RedirectToAction("/StudentClasses");
        }

        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(registerModel.UserEmail, registerModel.UserPassword);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new User(user.UserId, user.UserEmail, user.UserPassword, user.UserIsAdmin);

                    System.Web.Security.FormsAuthentication.SetAuthCookie(registerModel.UserEmail, false);

                    return Redirect(returnUrl);
                }
            }

            return View(registerModel);
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserEmail, loginModel.UserPassword);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new User(user.UserId,user.UserEmail, user.UserPassword, user.UserIsAdmin);

                    FormsAuthentication.SetAuthCookie(loginModel.UserEmail, false);

                    return Redirect(returnUrl);
                }
            }

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;

            FormsAuthentication.SignOut();

            return Redirect("~/Home/Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
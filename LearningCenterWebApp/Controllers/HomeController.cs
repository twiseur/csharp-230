using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenterBusiness;
using LearningCenterWebApp.Repositories;
using LearningCenterWebApp.Models;

namespace LearningCenterWebApp.Controllers
{
    public class HomeController : Controller
    {
        //IEnumerable<Class> Classes;
        //IEnumerable<User> Students;
        private readonly IUserManager userManager;
        private readonly IClassManager classManager;

        public HomeController(IUserManager userManager, IClassManager classManager)
        {
            //Classes = new ClassRepository().Classes;
            //Students = new StudentRepository().Students;
            this.userManager = userManager;
            this.classManager = classManager;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClassList()
        {
            //TODO Bind to repository ClassList
           // var ClassList = new ClassRepository().Classes;

            return View(classManager.Classes);
        }

        [Authorize]
        public ActionResult EnrolledClassList()
        {
            //TODO Bind to repository ClassList
            var EnrolledClassList = new ClassRepository().Classes;

            return View(EnrolledClassList);
        }

        //[Authorize]
        [HttpGet]
        public ActionResult Enroll()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Enroll(AddClassResponse addClassResponse)
        {

            //Dictionary<int, List<int>> StudentClasses;
            //StudentClasses = new StudentClassRepository().StudentClasses;

            ////Retrieve class
            //var classAdded = from tpClass in Classes
            //                 where tpClass.ClassName == addClassResponse.ClassAdded
            //                 select tpClass;

            //int classId = classAdded.First().ClassId;

            ////Retrieve the classes for the logged user
            //StudentClasses[1].Add(classId);

            //var enrolledClasses = Classes.Where(iclass => StudentClasses[1].Contains(iclass.ClassId));

            //return View("EnrolledClassList", enrolledClasses);

            return View();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult BirthdayCardForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BirthdayCardForm(Models.BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("BirthdayCardSummary", birthdayCard);
            }
            else
            {
                return View();
            }
        }
    }
}
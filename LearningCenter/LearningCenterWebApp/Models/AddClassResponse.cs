using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenterWebApp.Models;

namespace LearningCenterWebApp.Models
{
    public class AddClassResponse
    {
        public List<SelectListItem> AvailableClasses { get; set; }
        public string ClassAdded { get; set; }
    }
}
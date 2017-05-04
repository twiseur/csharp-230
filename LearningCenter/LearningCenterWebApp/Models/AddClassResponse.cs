using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningCenterWebApp.Models
{
    public class AddClassResponse
    {
        public List<SelectListItem> AvailableClasses { get; set; }
        public string ClassAdded { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCenterWebApp.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public double ClassPrice { get; set; }
        public int ClassSessions { get; set; }

        public Class (int ClassId, string ClassName, string ClassDescription, double ClassPrice, int ClassSessions)
        {
            this.ClassId = ClassId;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.ClassPrice = ClassPrice;
            this.ClassSessions = ClassSessions;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningCenterWebApp.Models;

namespace LearningCenterWebApp.Repositories
{

    public class ClassRepository
    {
        public IEnumerable<Class> Classes
        {
            get
            {
                var items = new[]
                {
                    new Class(1,"CSHP 230","C# Development Class",500,10),
                    new Class(2,"MTH 110","Numerical Analysis", 600, 8),
                    new Class(3, "FLMC 330", "Supersonic Travel", 430, 5),
                    new Class(4, "PSY 240", "Advanced Psychology", 200, 10)
                };
                return items;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningCenterWebApp.Models;

namespace LearningCenterWebApp.Repositories
{
    public class StudentRepository
    {
        public IEnumerable<User> Students
        {
            get
            {
                var items = new[]
                {
                    new User( 1, "Janet Mitchell", "jmpwd", false),
                    new User( 2, "Bill Johnson", "1234", false),
                    new User( 3, "Amanda Westbrook", "azertyuiop", false),
                    new User( 4, "John Michael", "CutePanda", false)
                };
                return items;
            }
        }
    }
}

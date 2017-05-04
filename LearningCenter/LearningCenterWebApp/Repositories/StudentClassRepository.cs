using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningCenterWebApp.Models;

namespace LearningCenterWebApp.Repositories
{
    public class StudentClassRepository
    {
        //public Dictionary<Student, List<Class>> StudentClasses
        //{
        //    get
        //    {
        //        var items = new Dictionary<Student, List<Class>>();
        //        Student john = new Student(1, "John", "jpwd");
        //        Student amy = new Student(2, "Amy", "apwd");
        //        Class cshp = new Class(1, "CSHP 230", "C# Development Class", 500, 10);
        //        Class math = new Class(2, "MTH 110", "Numerical Analysis", 600, 8);
        //        Class flmc = new Class(3, "FLMC 330", "Supersonic Travel", 430, 5);
        //        List<Class> johnlist = new List<Class>();
        //        johnlist.Add(cshp);
        //        johnlist.Add(math);
        //        items.Add(john, johnlist);
        //        List<Class> amylist = new List<Class>();
        //        amylist.Add(flmc);
        //        items.Add(amy, amylist);



        //        return items;
        //    }
        //}

        public Dictionary<int, List<int>> StudentClasses
        {
            get
            {
                var items = new Dictionary<int, List<int>>();
                items.Add(1, new List<int>() { 1,2});
                items.Add(2, new List<int>() { 3});
                items.Add(3, new List<int>() { 4});
                return items;
            }
        }
    }
}

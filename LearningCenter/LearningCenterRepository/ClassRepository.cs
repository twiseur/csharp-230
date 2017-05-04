using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenterRepository
{
    public interface IClassRepository
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int classId);
        ClassModel[] UserClasses(int userId);
        UserModel Add(int classId, int userId);
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    class ClassRepository : IClassRepository
    {
        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Class
                    .Select(t => new ClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                        ClassDescription = t.ClassDescription,
                        ClassPrice = t.ClassPrice
                    })
                    .ToArray();
            }
        }

        public ClassModel Class(int classId)
        {
            var currentClass = DatabaseAccessor.Instance.Class
                .Where(t => t.ClassId == classId)
                .Select(t => new ClassModel {
                    ClassId = t.ClassId,
                    ClassName = t.ClassName,
                    ClassDescription = t.ClassDescription,
                    ClassPrice = t.ClassPrice })
                .First();
            return currentClass;
        }

        public ClassModel[] UserClasses(int userId)
        {
            var classes = DatabaseAccessor.Instance.User.First(t => t.UserId == userId)
                                  .Class.Select(t =>
                                        new ClassModel
                                        {
                                            ClassId = t.ClassId,
                                            ClassName = t.ClassName,
                                            ClassDescription = t.ClassDescription,
                                            ClassPrice = t.ClassPrice
                                        })
                                        .ToArray();

            return classes;
        }

        public UserModel Add(int classId, int userId)
        {
            var user = DatabaseAccessor.Instance.User.First(t => t.UserId == userId);

            DatabaseAccessor.Instance.Class.First(t => t.ClassId == classId)
                .User.Add(user);

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { UserId = user.UserId, UserEmail = user.UserEmail, UserPassword = user.UserPassword, UserIsAdmin = user.UserIsAdmin};

        }
    }
}

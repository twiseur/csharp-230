using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenterRepository;

namespace LearningCenterBusiness
{
    public interface IClassManager
    {
        List<ClassModel> Classes { get; }
        ClassModel Class (int classId);
        List<ClassModel> UserClasses(int userId);
        UserModel Add(int classId, int userId);
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }

        public ClassModel(int classId, string className, string classDescription, decimal classPrice)
        {
            ClassId = classId;
            ClassName = className;
            ClassDescription = classDescription;
            ClassPrice = classPrice;
        }
    }

    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public List<ClassModel> Classes
        {
            get
            {
                return classRepository.Classes
                                     .Select(t => new ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                                     .ToList();
            }
        }

        public ClassModel Class(int classId)
        {
            var classModel = classRepository.Class(classId);
            return new ClassModel(classModel.ClassId, classModel.ClassName, classModel.ClassDescription, classModel.ClassPrice);
        }

        public List<ClassModel> UserClasses(int userId)
        {
            var classes = classRepository.UserClasses(userId)
                .Select(t => new ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                .ToList();

            return classes;
        }


        public UserModel Add(int classId, int userId)
        {
            var user = classRepository.Add(classId, userId);

            return new UserModel(user.UserId, user.UserEmail, user.UserPassword, user.UserIsAdmin);
        }
    }
}

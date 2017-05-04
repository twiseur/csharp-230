using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenterDatabase;

namespace LearningCenterRepository
{
    public interface IUserRepository
    {
        UserModel[] Users { get; }
        UserModel User(int userId);
        UserModel[] UsersInClass(int classId);
        void Add(UserModel userModel);
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }
    }

    class UserRepository : IUserRepository
    {
        public UserModel[] Users
        {
            get
            {
                return DatabaseAccessor.Instance.User
                                               .Select(t => new UserModel { UserId = t.UserId, UserEmail = t.UserEmail, UserPassword = t.UserPassword })
                                               .ToArray();
            }
        }

        public UserModel User(int userId)
        {
            var user = DatabaseAccessor.Instance.User
                                                   .Where(t => t.UserId == userId)
                                                   .Select(t => new UserModel { UserId = t.UserId, UserEmail = t.UserEmail, UserPassword = t.UserPassword })
                                                   .First();
            return user;
        }

        public UserModel[] UsersInClass(int classId)
        {
            var users = DatabaseAccessor.Instance.Class.First(t => t.ClassId == classId)
                                  .User.Select(t =>
                                        new UserModel
                                        {
                                            UserId = t.UserId,
                                            UserEmail = t.UserEmail,
                                            UserPassword = t.UserPassword,
                                            UserIsAdmin = t.UserIsAdmin
                                        })
                                        .ToArray();

            return users;
        }

        public User ToDbUser(UserModel userModel)
        {
            var userDb = new User
            {
                UserId = userModel.UserId,
                UserEmail = userModel.UserEmail,
                UserPassword = userModel.UserPassword,
                UserIsAdmin = userModel.UserIsAdmin
            };
            return userDb;
        }

        public void Add(UserModel userModel)
        {
            var userDb = ToDbUser(userModel);

            DatabaseAccessor.Instance.User.Add(userDb);
            DatabaseAccessor.Instance.SaveChanges();

        }

    }
}

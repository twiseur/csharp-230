using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenterRepository;

namespace LearningCenterBusiness
{

    public interface IUserManager
    {
        UserModel[] Users { get; }
        UserModel User(int userId);
        UserModel[] UsersInClass(int classId);
        UserModel Register(string email, string password);
        UserModel LogIn(string email, string password);
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }

        public UserModel(int userId, string userEmail, string userPassword, bool userIsAdmin)
        {
            UserId = userId;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserIsAdmin = userIsAdmin;
        }
    }

    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserModel[] Users
        {
            get
            {
                return userRepository.Users
                                     .Select(t => new UserModel(t.UserId, t.UserEmail, t.UserPassword, t.UserIsAdmin))
                                     .ToArray();
            }
        }

        public UserModel User(int userId)
        {
            var userModel = userRepository.User(userId);
            return new UserModel(userModel.UserId, userModel.UserEmail, userModel.UserPassword, userModel.UserIsAdmin);
        }

        public UserModel[] UsersInClass(int classId)
        {
            var users = userRepository.UsersInClass(classId)
                .Select(t => new UserModel(t.UserId, t.UserEmail, t.UserPassword, t.UserIsAdmin))
                .ToArray();

            return users;
        }

        public LearningCenterRepository.UserModel ToRepositoryUser(UserModel userModel)
        {
            var userRepository = new LearningCenterRepository.UserModel
            {
                UserId = userModel.UserId,
                UserEmail = userModel.UserEmail,
                UserPassword = userModel.UserPassword,
                UserIsAdmin = userModel.UserIsAdmin
            };
            return userRepository;
        }

        public UserModel Register(string email, string password)
        {
            var userRepo = userRepository.Register(email, password);

            if (userRepo == null)
            {
                return null;
            }

            return new UserModel(userRepo.UserId,userRepo.UserEmail,userRepo.UserPassword,userRepo.UserIsAdmin);
        }

        public UserModel LogIn(string email, string password)
        {
            var userRepo = userRepository.LogIn(email, password);

            if (userRepo == null)
            {
                return null;
            }

            return new UserModel(userRepo.UserId, userRepo.UserEmail, userRepo.UserPassword, userRepo.UserIsAdmin);
        }
    }
}


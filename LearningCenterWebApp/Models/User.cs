using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCenterWebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }

        public User(int UserId, string UserEmail, string UserPassword, bool UserIsAdmin)
        {
            this.UserId = UserId;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
            this.UserIsAdmin = UserIsAdmin;
        }

    }
}
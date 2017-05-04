using System.ComponentModel.DataAnnotations;

namespace LearningCenterWebApp.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}
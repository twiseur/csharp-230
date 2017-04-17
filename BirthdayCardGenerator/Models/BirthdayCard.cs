using System.ComponentModel.DataAnnotations;

namespace BirthdayCardGenerator.Models
{
    public class BirthdayCard
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's name")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}
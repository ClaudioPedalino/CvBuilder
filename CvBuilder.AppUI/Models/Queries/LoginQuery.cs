using System.ComponentModel.DataAnnotations;

namespace CvBuilder.AppUI.Models.Queries
{
    public class LoginQuery
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

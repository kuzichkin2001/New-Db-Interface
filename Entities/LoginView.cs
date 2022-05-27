using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class LoginView
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

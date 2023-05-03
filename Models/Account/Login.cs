using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication2.Models.Account
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("E-mail")]
        [MinLength(6, ErrorMessage = "Must enter valid e-mail address!")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must be of minimum 6 characters!")]
        public string Password { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Account
{
    public class Register : Login
    {
        [Required]
        [DisplayName("First name")]
        public string Fname { get; set; }
        [DisplayName("Last name")]
        public string Lname { get; set; }
        [DisplayName("Birthday")]
        public DateTime Bday { get; set; }
        public Gender gender { get; set; }

        [DisplayName("Password repeat")]
        public string PassRepeat { get; set; }

        public enum Gender
        {
            [Display(Name = "Man")]
            Man,
            [Display(Name = "Woman")]
            Woman
        }
    }
}

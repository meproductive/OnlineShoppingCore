using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCore.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter an Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter an email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter repassword")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter an adress")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Please enter birthdate")]
        public string BirthDate { get; set; }
        //[Required(ErrorMessage = "You must agree to terms and conditions")]
        //public bool IsActive { get; set; }

    }
}

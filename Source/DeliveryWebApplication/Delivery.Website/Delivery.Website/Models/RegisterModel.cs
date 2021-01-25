using System.ComponentModel.DataAnnotations;

namespace Delivery.Website.Areas.Admin.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must contain from 3 to 50 symbols")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must contain from 5 to 50 symbols")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$", ErrorMessage = "Password must contain at least 1 numeric and 1 uppercase character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDriver { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Firstname must contain only letters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Lastname must contain only letters")]
        public string LastName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GameShopV3.Models.ViewModels
{
    public class RegisterPlayerViewModel
    {
        [Required(ErrorMessage = "Enter Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Date of Birth")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}

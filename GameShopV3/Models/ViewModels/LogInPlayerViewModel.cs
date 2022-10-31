using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GameShopV3.Models.ViewModels
{
    public class LogInPlayerViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Interns.Services.Models
{
    public class LoginInputModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(150, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
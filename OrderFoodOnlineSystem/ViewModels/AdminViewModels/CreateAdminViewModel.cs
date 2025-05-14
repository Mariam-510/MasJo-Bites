using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.AdminViewModels
{
    public class CreateAdminViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

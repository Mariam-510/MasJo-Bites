using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.AccountViewModels
{
    public class EmailFormViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
    }
}

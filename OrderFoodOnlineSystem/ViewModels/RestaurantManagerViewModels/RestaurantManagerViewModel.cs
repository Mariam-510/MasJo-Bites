using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantManagerViewModels
{
    public class RestaurantManagerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public int? RestaurantId { get; set; }
        //public string? RestaurantName { get; set; }

    }
}

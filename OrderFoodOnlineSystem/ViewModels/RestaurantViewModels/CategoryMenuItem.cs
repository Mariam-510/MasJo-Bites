using OrderFoodOnlineSystem.Models;
using System.ComponentModel;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantViewModels
{
    public class CategoryMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MenuItem>? MenuItems { get; set; }

    }
}

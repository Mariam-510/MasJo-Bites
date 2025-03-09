using OrderFoodOnlineSystem.Models;
using System.Collections;
using System.Collections.Generic;

namespace OrderFoodOnlineSystem.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string RestaurantName { get; set; }
        public string AddressDetails { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

    }

}

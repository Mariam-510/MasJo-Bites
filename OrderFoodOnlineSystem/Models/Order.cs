using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Customer")]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }


        [ForeignKey("Address")]
        [Display(Name = "Delivery Address")]
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }


        [Required]
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;


        [ForeignKey("Restaurant")]
        [Display(Name = "Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        [Display(Name = "Order Items")]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        OutForDelivery,
        Delivered,
        Cancelled
    }
    public enum PaymentMethod
    {
        Cash,
        PayPal,
        
    }

}

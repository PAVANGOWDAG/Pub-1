using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Pub_Mangement.Models.Enums;

namespace Pub_Mangement.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public int TableId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public int? CustomerId { get; set; }

        public Table Table { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

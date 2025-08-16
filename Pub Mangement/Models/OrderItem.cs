using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pub_Mangement.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000)]
        public decimal Price { get; set; }

        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Pub_Mangement.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}

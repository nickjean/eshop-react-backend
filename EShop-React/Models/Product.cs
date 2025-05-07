using EShop_React.Enum;
using System.ComponentModel.DataAnnotations;

namespace EShop_React.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Gender> Gender { get; set; } = new List<Gender>();
        public string? Color { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<WishlistProduct> WishlistProducts { get; set; }
    }
}

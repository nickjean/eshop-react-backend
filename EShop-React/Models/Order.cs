using System.ComponentModel.DataAnnotations;

namespace EShop_React.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }

        // List of products in this order
        public ICollection<OrderItem> Items { get; set; }
    }
}

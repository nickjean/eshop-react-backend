using System.ComponentModel.DataAnnotations;

namespace EShop_React.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        // FK to ApplicationUser
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // Products in this wishlist (many-to-many)
        public ICollection<WishlistProduct> WishlistProducts { get; set; }
    }
}

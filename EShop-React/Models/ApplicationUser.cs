using Microsoft.AspNetCore.Identity;

namespace EShop_React.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}

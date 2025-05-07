namespace EShop_React.Models
{
    public class WishlistProduct
    {
        public int Id { get; set; }
        public Wishlist Wishlist { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

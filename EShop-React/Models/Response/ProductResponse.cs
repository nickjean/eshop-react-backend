using EShop_React.Enum;

namespace EShop_React.Models.Response
{
    public class ProductResponse
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Gender> Gender { get; set; } = new List<Gender>();
    }
}

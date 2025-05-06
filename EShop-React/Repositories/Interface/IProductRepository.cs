using EShop_React.Command;
using EShop_React.Models;
using EShop_React.Models.Response;

namespace EShop_React.Repositories.Interface
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<List<Product>> GetAllProducts(CancellationToken cancellationToken);
    }
}

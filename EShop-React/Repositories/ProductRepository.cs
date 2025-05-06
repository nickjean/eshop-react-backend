using EShop_React.Command;
using EShop_React.Data;
using EShop_React.Models;
using EShop_React.Models.Response;
using EShop_React.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EShop_React.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateProduct(Product product)
        {            
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();           
        }

        public async Task<List<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.ToListAsync(cancellationToken);
        }
    }
}

using EShop_React.Data;
using EShop_React.Models;
using EShop_React.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EShop_React.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Order>> GetAllOrdersForUser(string id)
        {
            return await _appDbContext.Orders
                .Where(o => o.ApplicationUser.Id == id)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product).ToListAsync();
        }
    }
}

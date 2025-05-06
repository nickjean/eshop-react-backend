using EShop_React.Models;

namespace EShop_React.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersForUser(string id);
    }
}

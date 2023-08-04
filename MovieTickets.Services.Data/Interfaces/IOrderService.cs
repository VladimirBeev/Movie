using MovieTickets.Data.EntityModels;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItems> items, string userId, string userEmail);
        Task<List<Order>> GetAllOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}

using MovieTickets.Data.EntityModels;

namespace MovieTickets.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task StoreOrderAsync(ICollection<ShoppingCartItems> items, string userId, string userEmail);
        Task<ICollection<Order>> GetAllOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}

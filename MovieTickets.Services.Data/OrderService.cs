using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;

namespace MovieTickets.Services.Data
{
	public class OrderService : IOrderService
	{
		private readonly MovieDbContext dbContext;

		public OrderService(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<ICollection<Order>> GetAllOrdersByUserIdAndRoleAsync(string userId, string userRole)
		{
			var orders = await dbContext.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(m => m.Movie)
				.Include(u => u.User)
				.ToListAsync();

			if (userRole != "Admin")
			{
				orders = orders.Where(u => u.UserId.ToString() == userId).ToList();
			}

			return orders;
		}

		public async Task StoreOrderAsync(ICollection<ShoppingCartItems> items, string userId, string userEmail)
		{
			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
			if (user == null)
			{
                var order = new Order();
                order.UserId = user.Id;
                order.Email = userEmail;

                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();

                foreach (var item in items)
                {
                    var orderItem = new OrderItem();
                    orderItem.Amount = item.Amount;
                    orderItem.MovieId = item.Movie.Id;
                    orderItem.OrderId = order.Id;
                    orderItem.Price = item.Movie.Price;

                    await dbContext.OrderItems.AddAsync(orderItem);
                }

                await dbContext.SaveChangesAsync();
            }
			
		}
	}
}

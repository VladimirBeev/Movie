using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.Infrastructure.Extensions;
using MovieTickets.Web.ViewModels.Cart;

using Shopping;

namespace MovieTickets.Web.Controllers
{
	public class OrderController : Controller
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IMovieService movieService;
        private readonly IOrderService orderService;

		public OrderController(ShoppingCart shoppingCart,
            IMovieService movieService, IOrderService orderService)
        {
            this.shoppingCart = shoppingCart;
            this.movieService = movieService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> AllOrders()
        {
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //string userRole = User.FindFirstValue(ClaimTypes.Role);

            string userId = User.Id();

            string userRole = User.Role();

            var orders = await orderService.GetAllOrdersByUserIdAndRoleAsync(userId, userRole);

            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = shoppingCart.GetShoppingCartItems();

            shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await movieService.GetMovieByIdAsync(id);

            if (item != null)
            {
                shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await movieService.GetMovieByIdAsync(id);

            if (item != null)
            {
                shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = shoppingCart.GetShoppingCartItems();

            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

			string userId = User.Id();

			string userEmailAddress = User.Email();

			await orderService.StoreOrderAsync(items, userId, userEmailAddress);

            await shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}

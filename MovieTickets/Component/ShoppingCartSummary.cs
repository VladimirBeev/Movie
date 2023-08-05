using Microsoft.AspNetCore.Mvc;

using Shopping;

namespace MovieTickets.Web.Component
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}

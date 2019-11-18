using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FanCentral2.Infrastructure;
using FanCentral2.Data;
using FanCentral2.Models;
using FanCentral2.Models.ViewModels;

namespace FanCentral2.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDBContext _context;

        private Cart cart;

        public CartController(ApplicationDBContext context, Cart cartService)
        {
            _context = context;
            cart = cartService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productID, string returnUrl)
        {
            Product product = _context.Products
            .FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _context.Products
            .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
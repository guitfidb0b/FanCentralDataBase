using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FanCentral2.Infrastructure;
using FanCentral2.Data;
using FanCentral2.Models;
using FanCentral2.Models.ViewModels;

namespace FanCentral2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CategoriesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index(int? id, int? productID, string searchString)
        {
            ViewData["SearchString"] = searchString;
            
            //This is how we load all data into the view (using eager loading)
            var viewModel = new BrowseProductCategories();
            viewModel.Categories = await _context.Categories
                .Include(c => c.ProductCategories)
                    .ThenInclude(c => c.Product)
                .AsNoTracking()
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                ViewData["CategoryID"] = id.Value;
                Category category = viewModel.Categories.Where( c => c.CategoryID == id.Value).Single();
                viewModel.Products = category.ProductCategories.Select(s => s.Product);
            }
            if (productID != null)
            {
                ViewData["ProductID"] = productID.Value;
                viewModel.ProductCategories = viewModel.Products.Where(x => x.ProductID == productID).Single().ProductCategories;
            }
            if (!String.IsNullOrEmpty(searchString))
            {   
                var products = from p in _context.Products
                                select p;
                viewModel.Products = viewModel.Products.Where(p => p.Description.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Product(int? id)
        {
            var viewModel = new BrowseProductCategories();
            viewModel.Products = await _context.Products
                .AsNoTracking()
                .OrderBy(p => p.ProductID)
                .ToListAsync();

            if (id != null)
            {
                ViewData["ProductID"] = id.Value;
                Product product = viewModel.Products.Where(x => x.ProductID == id).Single();
            }

            return View(viewModel);
        }

        public ViewResult Cart(string returnUrl)
        {
            return View(new BrowseProductCategories
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productID, string returnUrl)
        {
            Product product = _context.Products
            .FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            
            return RedirectToAction("Cart", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _context.Products
            .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Cart", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}

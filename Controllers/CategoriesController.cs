using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index(
            int? id, 
            int? productID, 
            string sortOrder, 
            string CurrentFilter,
            string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PriceSortParm"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";
            ViewData["CurrentFilter"] = searchString;
            
            //This is how we load all data into the view (using eager loading)
            ViewData["CurrentFilter"] = searchString;
            var viewModel = new CategoriesIndexViewModel();
            
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
            switch (sortOrder)
            {
                case "price_desc":
                    viewModel.Products = viewModel.Products.OrderByDescending(p => (float)p.Price);
                    ViewData["WhichSort"] = 1;
                    break;
                case "price_asc":
                    viewModel.Products = viewModel.Products.OrderBy(p => (float)p.Price);
                    ViewData["WhichSort"] = 0;
                    break;
                default:
                    viewModel.Products = viewModel.Products.OrderBy(p => (float)p.Price);
                    break;
            }

            return View(viewModel);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}

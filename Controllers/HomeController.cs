using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FanCentral2.Data;
using FanCentral2.Models;
using FanCentral2.Models.ViewModels;

namespace FanCentral2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id, int? productID)
        {
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

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

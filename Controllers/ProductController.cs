using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FanCentral2.Data;
using FanCentral2.Models;
using FanCentral2.Models.ViewModels;

namespace FanCentral2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new ProductIndexViewModel();
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
    }
}
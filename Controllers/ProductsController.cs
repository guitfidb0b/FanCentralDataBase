using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FanCentral2.Data;
using FanCentral2.Models;

namespace FanCentral2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductsController(ApplicationDBContext context)
        {
            _context = context;
        }


        // GET: Products
        public async Task<IActionResult> Index(
            string sortOrder, 
            string CurrentFilter, 
            string searchString, 
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PriceSortParm"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var products = from p in _context.Products
                .Include(pc => pc.ProductCategories)
                    .ThenInclude(c => c.Category)
                .AsNoTracking()
                select p;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(p => (float)p.Price);
                    break;
                case "price_asc":
                    products = products.OrderBy(p => (float)p.Price);
                    break;
                default:
                    products = products.OrderBy(p => (float)p.Price);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(pc => pc.ProductCategories)
                    .ThenInclude(c => c.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,ImageName,Price")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (add ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (await TryUpdateModelAsync<Product>(
                productToUpdate,
                "",
                p => p.Description, p => p.ImageName, p => p.Price))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    //Log the error (uncomment ex variable...)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(productToUpdate);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? SaveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            if (SaveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = 
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                //Log the error add variable name ex
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true});
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}

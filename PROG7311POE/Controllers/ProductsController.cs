using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROG7311POE.Data;
using PROG7311POE.Models;

namespace PROG7311POE.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }



        
        
        public async Task<IActionResult> Index(string searchQuery, string farmerName, DateTime? startDate, DateTime? endDate, string productType)
        {
            var productsQuery = _context.Products.AsQueryable();

            
            if (!string.IsNullOrEmpty(searchQuery))
            {
                productsQuery = productsQuery.Where(p => p.FarmerName.Contains(searchQuery));
            }

            
            if (!string.IsNullOrEmpty(farmerName))
            {
                productsQuery = productsQuery.Where(p => p.FarmerName.Contains(farmerName));
            }

            
            if (startDate.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.DateSupplied >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.DateSupplied <= endDate.Value);
            }

            
            if (!string.IsNullOrEmpty(productType))
            {
                productsQuery = productsQuery.Where(p => p.ProductName.Contains(productType));
            }

            var products = await productsQuery.ToListAsync();
            return View(products);
        }








        
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,Quantity,DateSupplied,FarmerName")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
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

        [Authorize(Roles = "Employee, Farmer")]
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Quantity,DateSupplied,FarmerName")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}

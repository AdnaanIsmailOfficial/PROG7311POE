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
    [Authorize(Roles="Employee")]
    public class FarmersController : Controller
    {
        private readonly AppDbContext _context;

        public FarmersController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
              return _context.Farmers != null ? 
                          View(await _context.Farmers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Farmers'  is null.");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerID == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerID,FarmerName,FarmerLocation")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmer);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerID,FarmerName,FarmerLocation")] Farmer farmer)
        {
            if (id != farmer.FarmerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.FarmerID))
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
            return View(farmer);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerID == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmers == null)
            {
                return Problem("Entity set 'AppDbContext.Farmers'  is null.");
            }
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerExists(int id)
        {
          return (_context.Farmers?.Any(e => e.FarmerID == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PanPanBakery.Models;
using PanPanBakerys.Data;

namespace PanPanBakerys.Controllers
{
    public class CakeBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CakeBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CakeBookings
        public async Task<IActionResult> Index()
        {
              return _context.CakeBookings != null ? 
                          View(await _context.CakeBookings.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CakeBookings'  is null.");
        }

        // Display: CakeBookings
        public async Task<IActionResult> DisplayCakes()
        {
            return _context.CakeBookings != null ?
                        View(await _context.CakeBookings.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.CakeBooking'  is null.");
        }

        // GET: CakeBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CakeBookings == null)
            {
                return NotFound();
            }

            var cakeBookings = await _context.CakeBookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cakeBookings == null)
            {
                return NotFound();
            }

            return View(cakeBookings);
        }

        // GET: CakeBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CakeBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CakeName,CakeDescription,price,ImageName")] CakeBookings cakeBookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cakeBookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cakeBookings);
        }

        // GET: CakeBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CakeBookings == null)
            {
                return NotFound();
            }

            var cakeBookings = await _context.CakeBookings.FindAsync(id);
            if (cakeBookings == null)
            {
                return NotFound();
            }
            return View(cakeBookings);
        }

        // POST: CakeBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CakeName,CakeDescription,price,ImageName")] CakeBookings cakeBookings)
        {
            if (id != cakeBookings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cakeBookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeBookingsExists(cakeBookings.Id))
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
            return View(cakeBookings);
        }

        // GET: CakeBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CakeBookings == null)
            {
                return NotFound();
            }

            var cakeBookings = await _context.CakeBookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cakeBookings == null)
            {
                return NotFound();
            }

            return View(cakeBookings);
        }

        // POST: CakeBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CakeBookings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CakeBookings'  is null.");
            }
            var cakeBookings = await _context.CakeBookings.FindAsync(id);
            if (cakeBookings != null)
            {
                _context.CakeBookings.Remove(cakeBookings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeBookingsExists(int id)
        {
          return (_context.CakeBookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

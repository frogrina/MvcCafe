using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCafe.Data;
using MvcCafe.Models;

namespace MvcCafe.Controllers
{
    public class CafesController : Controller
    {
        private readonly MvcCafeContext _context;

        public CafesController(MvcCafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Browse()
        {
            var cafes = await _context.Cafes.ToListAsync();
            return View(cafes);
        }

        public async Task<IActionResult> Admin(string ownerId)
        {
            return null;
        }

        public async Task<IActionResult> IncrementCurrentLoad(int id, string ownerId, int incrementValue)
        {
            return null;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafe == null)
            {
                return NotFound();
            }

            return View(cafe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CurrentLoad,MaxLoad")] Cafe cafe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafe);
        }

        // GET: Cafes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafes.FindAsync(id);
            if (cafe == null)
            {
                return NotFound();
            }
            return View(cafe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CurrentLoad,MaxLoad")] Cafe cafe)
        {
            if (id != cafe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeExists(cafe.Id))
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
            return View(cafe);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafe == null)
            {
                return NotFound();
            }

            return View(cafe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafe = await _context.Cafes.FindAsync(id);
            _context.Cafes.Remove(cafe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeExists(int id)
        {
            return _context.Cafes.Any(e => e.Id == id);
        }
    }
}

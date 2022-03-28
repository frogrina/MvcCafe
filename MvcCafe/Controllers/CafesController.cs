#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var cafes = await _context.Cafe.ToListAsync();
            return View(cafes);
        }

        public async Task<IActionResult> Admin(string ownerId)
        {
            var adminPassword = "frog";
            if (ownerId == adminPassword)
            {
                var cafes = from m in _context.Cafe
                            select m;

                return View(await cafes.ToListAsync());
            }
            else if (!string.IsNullOrEmpty(ownerId))
            {
                var cafesWithOwnerEnumerable = _context.Cafe.Where(c => c.OwnerId.ToString() == ownerId);
                var cafes = await cafesWithOwnerEnumerable.ToListAsync();
                return View(cafes);
            }

            return View(new List<Cafe>());
        }

        public async Task<IActionResult> IncrementCurrentLoad(int id, string ownerId, int incrementValue)
        {
            var cafe = await _context.Cafe.FindAsync(id);
            if (cafe.OwnerId.ToString().Equals(ownerId))
            {
                cafe.CurrentLoad += incrementValue;
                _context.Update(cafe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Admin", "Cafes", new RouteValueDictionary { { "ownerId", ownerId } });
            }
            else return RedirectToAction("Browse", "Cafes");
        }

        // GET: Cafes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafe == null)
            {
                return NotFound();
            }

            return View(cafe);
        }

        // GET: Cafes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cafes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CurrentLoad,MaxLoad")] Cafe cafe)
        {
            if (ModelState.IsValid)
            {
                cafe.OwnerId = Guid.NewGuid();
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

            var cafe = await _context.Cafe.FindAsync(id);
            if (cafe == null)
            {
                return NotFound();
            }
            return View(cafe);
        }

        // POST: Cafes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Cafes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafe == null)
            {
                return NotFound();
            }

            return View(cafe);
        }

        // POST: Cafes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafe = await _context.Cafe.FindAsync(id);
            _context.Cafe.Remove(cafe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeExists(int id)
        {
            return _context.Cafe.Any(e => e.Id == id);
        }
    }
}

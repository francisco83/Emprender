using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emprender.Data;
using Emprender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Emprender.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvincesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/

        public async Task<IActionResult> Index()
        {
            IList<ProvincesClass> provinces = new List<ProvincesClass>();
            provinces = _context.ProvincesClass.ToList();
            return View(await _context.ProvincesClass.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProvincesClass provinces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provinces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provinces);
        }


        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinces = await _context.ProvincesClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provinces == null)
            {
                return NotFound();
            }

            return View(provinces);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinces = await _context.ProvincesClass.FindAsync(id);
            if (provinces == null)
            {
                return NotFound();
            }
            return View(provinces);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProvincesClass Provinces)
        {
            if (id != Provinces.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Provinces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvincesExists(Provinces.Id))
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
            return View(Provinces);


        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinces = await _context.ProvincesClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provinces == null)
            {
                return NotFound();
            }

            return View(provinces);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provinces = await _context.ProvincesClass.FindAsync(id);
            _context.ProvincesClass.Remove(provinces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ProvincesExists(int id)
        {
            return _context.ProvincesClass.Any(e => e.Id == id);
        }
    }
}

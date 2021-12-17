using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emprender.Data;
using Emprender.Models;

namespace Emprender.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            IList<Clientes> clientes = new List<Clientes>();
            clientes =  _context.Clientes.ToList();

            List<ProvincesClass> provincias = new List<ProvincesClass>();
            provincias = _context.ProvincesClass.ToList();
            ViewBag.Provincias = provincias;

            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Clientes == null)
            {
                return NotFound();
            }

            return View(Clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Email,Telefono")] Clientes Clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<ProvincesClass> provincias = new List<ProvincesClass>();
            provincias = _context.ProvincesClass.ToList();
            ViewBag.Provincias = provincias;

            return View(Clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Clientes = await _context.Clientes.FindAsync(id);
            if (Clientes == null)
            {
                return NotFound();
            }

            List<ProvincesClass> provincias = new List<ProvincesClass>();
            provincias = _context.ProvincesClass.ToList();
            ViewBag.Provincias = provincias;

            List<Empresas> Empresas = new List<Empresas>();
            Empresas = _context.Empresas.ToList();
            ViewBag.Empresas = Empresas;
            


            return View(Clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Email,Telefono,ProvinciaId,Direccion,Habilitado,EmpresaId")] Clientes Clientes)
        {
            if (id != Clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(Clientes.Id))
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
            return View(Clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Clientes == null)
            {
                return NotFound();
            }

            return View(Clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(Clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}

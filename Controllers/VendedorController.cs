#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FranciscoDavidSantosSousa.Models;

namespace FranciscoDavidSantosSousa.Controllers
{
    public class VendedorController : Controller
    {
        private readonly MyDbContext _context;

        public VendedorController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Vendedor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendedors.ToListAsync());
        }

        // GET: Vendedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors
                .FirstOrDefaultAsync(m => m.IdVendedor == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // GET: Vendedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVendedor,nome,NotaDeVendaId")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        // GET: Vendedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVendedor,nome,NotaDeVendaId")] Vendedor vendedor)
        {
            if (id != vendedor.IdVendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.IdVendedor))
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
            return View(vendedor);
        }

        // GET: Vendedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors
                .FirstOrDefaultAsync(m => m.IdVendedor == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedor = await _context.Vendedors.FindAsync(id);
            _context.Vendedors.Remove(vendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
            return _context.Vendedors.Any(e => e.IdVendedor == id);
        }
    }
}

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
    public class ItemController : Controller
    {
        private readonly MyDbContext _context;

        public ItemController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Item.Include(i => i.NotaDeVenda).Include(i => i.Produto);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.NotaDeVenda)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.IdItem == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "IdNotaDeVenda", "IdNotaDeVenda");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "IdProduto", "IdProduto");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdItem,preco,percentual,quantidade,ProdutoId,NotaDeVendaId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "IdNotaDeVenda", "IdNotaDeVenda", item.NotaDeVendaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", item.ProdutoId);
            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "IdNotaDeVenda", "IdNotaDeVenda", item.NotaDeVendaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", item.ProdutoId);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdItem,preco,percentual,quantidade,ProdutoId,NotaDeVendaId")] Item item)
        {
            if (id != item.IdItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdItem))
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
            ViewData["NotaDeVendaId"] = new SelectList(_context.NotaDeVenda, "IdNotaDeVenda", "IdNotaDeVenda", item.NotaDeVendaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", item.ProdutoId);
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.NotaDeVenda)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.IdItem == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.IdItem == id);
        }
    }
}

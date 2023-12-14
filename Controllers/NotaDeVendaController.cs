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
    public class NotaDeVendaController : Controller
    {
        private readonly MyDbContext _context;

        public NotaDeVendaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotaDeVenda
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.NotaDeVenda.Include(n => n.Cliente).Include(n => n.TipoDePagamento).Include(n => n.Transportadora).Include(n => n.Vendedor);
            return View(await myDbContext.ToListAsync());
        }

        // GET: NotaDeVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.IdNotaDeVenda == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["PagamentoId"] = new SelectList(_context.TipoDePagamento, "IdTipoDePagamento", "Discriminator");
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadora, "IdTransportadora", "IdTransportadora");
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "IdVendedor", "IdVendedor");
            return View();
        }

        // POST: NotaDeVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNotaDeVenda,DataDaVenda,tipo,cancelado,devolvido,TipoDePagamentoId,PagamentoId,TransportadoraId,VendedorId,ClienteId,ItemId")] NotaDeVenda notaDeVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaDeVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", notaDeVenda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.TipoDePagamento, "IdTipoDePagamento", "Discriminator", notaDeVenda.PagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadora, "IdTransportadora", "IdTransportadora", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "IdVendedor", "IdVendedor", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", notaDeVenda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.TipoDePagamento, "IdTipoDePagamento", "Discriminator", notaDeVenda.PagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadora, "IdTransportadora", "IdTransportadora", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "IdVendedor", "IdVendedor", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNotaDeVenda,DataDaVenda,tipo,cancelado,devolvido,TipoDePagamentoId,PagamentoId,TransportadoraId,VendedorId,ClienteId,ItemId")] NotaDeVenda notaDeVenda)
        {
            if (id != notaDeVenda.IdNotaDeVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaDeVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaDeVendaExists(notaDeVenda.IdNotaDeVenda))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", notaDeVenda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.TipoDePagamento, "IdTipoDePagamento", "Discriminator", notaDeVenda.PagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadora, "IdTransportadora", "IdTransportadora", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedors, "IdVendedor", "IdVendedor", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotaDeVenda
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.IdNotaDeVenda == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDeVenda = await _context.NotaDeVenda.FindAsync(id);
            _context.NotaDeVenda.Remove(notaDeVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaDeVendaExists(int id)
        {
            return _context.NotaDeVenda.Any(e => e.IdNotaDeVenda == id);
        }
    }
}

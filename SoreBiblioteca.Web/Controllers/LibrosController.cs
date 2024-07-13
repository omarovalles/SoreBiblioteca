using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoreBiblioteca.Domain.Entities;
using SoreBiblioteca.Web.Models;
using SoreBiblioteca.Web.Persistence;

namespace SoreBiblioteca.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly SoreLibraryContext _context;

        public LibrosController(SoreLibraryContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var soreLibraryContext = _context.Libros.Include(l => l.IdproveedorNavigation);
            return View("LibrosPage", await soreLibraryContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdproveedorNavigation)
                .FirstOrDefaultAsync(m => m.Idlibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["Idproveedor"] = new SelectList(_context.Proveedores, "Idproveedor", "Idproveedor");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlibro,Autor,Titulo,Idproveedor,Stock")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idproveedor"] = new SelectList(_context.Proveedores, "Idproveedor", "Idproveedor", libro.Idproveedor);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["Idproveedor"] = new SelectList(_context.Proveedores, "Idproveedor", "Idproveedor", libro.Idproveedor);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlibro,Autor,Titulo,Idproveedor,Stock")] Libro libro)
        {
            if (id != libro.Idlibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Idlibro))
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
            ViewData["Idproveedor"] = new SelectList(_context.Proveedores, "Idproveedor", "Idproveedor", libro.Idproveedor);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdproveedorNavigation)
                .FirstOrDefaultAsync(m => m.Idlibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Idlibro == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Prestar(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            if (libro.Stock > 0)
            {
                libro.Stock -= 1;
                _context.Update(libro);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }

}

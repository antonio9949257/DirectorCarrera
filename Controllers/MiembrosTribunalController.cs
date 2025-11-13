using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTitulos.Data;
using SistemaTitulos.Models;

namespace SistemaTitulos.Controllers
{
    public class MiembrosTribunalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiembrosTribunalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MiembrosTribunal
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiembroTribunal.ToListAsync());
        }

        // GET: MiembrosTribunal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembroTribunal = await _context.MiembroTribunal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miembroTribunal == null)
            {
                return NotFound();
            }

            return View(miembroTribunal);
        }

        // GET: MiembrosTribunal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiembrosTribunal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Especialidad,Activo")] MiembroTribunal miembroTribunal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembroTribunal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miembroTribunal);
        }

        // GET: MiembrosTribunal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembroTribunal = await _context.MiembroTribunal.FindAsync(id);
            if (miembroTribunal == null)
            {
                return NotFound();
            }
            return View(miembroTribunal);
        }

        // POST: MiembrosTribunal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Especialidad,Activo")] MiembroTribunal miembroTribunal)
        {
            if (id != miembroTribunal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembroTribunal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroTribunalExists(miembroTribunal.Id))
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
            return View(miembroTribunal);
        }

        // GET: MiembrosTribunal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembroTribunal = await _context.MiembroTribunal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miembroTribunal == null)
            {
                return NotFound();
            }

            return View(miembroTribunal);
        }

        // POST: MiembrosTribunal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miembroTribunal = await _context.MiembroTribunal.FindAsync(id);
            if (miembroTribunal != null)
            {
                _context.MiembroTribunal.Remove(miembroTribunal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroTribunalExists(int id)
        {
            return _context.MiembroTribunal.Any(e => e.Id == id);
        }
    }
}

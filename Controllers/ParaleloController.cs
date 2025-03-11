using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGestionCursos.Data;
using SistemaGestionCursos.Models;

namespace SistemaGestionCursos.Controllers
{
    public class ParaleloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParaleloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paralelo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paralelos.ToListAsync());
        }

        // GET: Paralelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paraleloModel = await _context.Paralelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paraleloModel == null)
            {
                return NotFound();
            }

            return View(paraleloModel);
        }

        // GET: Paralelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paralelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] ParaleloModel paraleloModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paraleloModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paraleloModel);
        }

        // GET: Paralelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paraleloModel = await _context.Paralelos.FindAsync(id);
            if (paraleloModel == null)
            {
                return NotFound();
            }
            return View(paraleloModel);
        }

        // POST: Paralelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] ParaleloModel paraleloModel)
        {
            if (id != paraleloModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paraleloModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParaleloModelExists(paraleloModel.Id))
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
            return View(paraleloModel);
        }

        // GET: Paralelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paraleloModel = await _context.Paralelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paraleloModel == null)
            {
                return NotFound();
            }

            return View(paraleloModel);
        }

        // POST: Paralelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paraleloModel = await _context.Paralelos.FindAsync(id);
            if (paraleloModel != null)
            {
                _context.Paralelos.Remove(paraleloModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParaleloModelExists(int id)
        {
            return _context.Paralelos.Any(e => e.Id == id);
        }
    }
}

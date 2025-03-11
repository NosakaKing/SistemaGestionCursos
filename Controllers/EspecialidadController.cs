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
    public class EspecialidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especialidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidades.ToListAsync());
        }

        // GET: Especialidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadModel = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidadModel == null)
            {
                return NotFound();
            }

            return View(especialidadModel);
        }

        // GET: Especialidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] EspecialidadModel especialidadModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidadModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidadModel);
        }

        // GET: Especialidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadModel = await _context.Especialidades.FindAsync(id);
            if (especialidadModel == null)
            {
                return NotFound();
            }
            return View(especialidadModel);
        }

        // POST: Especialidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] EspecialidadModel especialidadModel)
        {
            if (id != especialidadModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidadModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadModelExists(especialidadModel.Id))
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
            return View(especialidadModel);
        }

        // GET: Especialidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadModel = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidadModel == null)
            {
                return NotFound();
            }

            return View(especialidadModel);
        }

        // POST: Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especialidadModel = await _context.Especialidades.FindAsync(id);
            if (especialidadModel != null)
            {
                _context.Especialidades.Remove(especialidadModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadModelExists(int id)
        {
            return _context.Especialidades.Any(e => e.Id == id);
        }
    }
}

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
    public class IncripcionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncripcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Incripcion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Incripciones.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Incripcion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incripcionModel = await _context.Incripciones
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incripcionModel == null)
            {
                return NotFound();
            }

            return View(incripcionModel);
        }

        // GET: Incripcion/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Descripcion");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Email");
            return View();
        }

        // POST: Incripcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaIncripcion,EstudianteId,CursoId")] IncripcionModel incripcionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incripcionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Descripcion", incripcionModel.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Email", incripcionModel.EstudianteId);
            return View(incripcionModel);
        }

        // GET: Incripcion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incripcionModel = await _context.Incripciones.FindAsync(id);
            if (incripcionModel == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Descripcion", incripcionModel.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Email", incripcionModel.EstudianteId);
            return View(incripcionModel);
        }

        // POST: Incripcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaIncripcion,EstudianteId,CursoId")] IncripcionModel incripcionModel)
        {
            if (id != incripcionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incripcionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncripcionModelExists(incripcionModel.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Descripcion", incripcionModel.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Email", incripcionModel.EstudianteId);
            return View(incripcionModel);
        }

        // GET: Incripcion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incripcionModel = await _context.Incripciones
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incripcionModel == null)
            {
                return NotFound();
            }

            return View(incripcionModel);
        }

        // POST: Incripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incripcionModel = await _context.Incripciones.FindAsync(id);
            if (incripcionModel != null)
            {
                _context.Incripciones.Remove(incripcionModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncripcionModelExists(int id)
        {
            return _context.Incripciones.Any(e => e.Id == id);
        }
    }
}

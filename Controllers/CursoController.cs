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
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Curso
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cursos.Include(c => c.Especialidad).Include(c => c.Paralelo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos
                .Include(c => c.Especialidad)
                .Include(c => c.Paralelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            return View(cursoModel);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Descripcion");
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre");
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaInicio,FechaFin,ParaleloId,EspecialidadId")] CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Descripcion", cursoModel.EspecialidadId);
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", cursoModel.ParaleloId);
            return View(cursoModel);
        }

        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.FindAsync(id);
            if (cursoModel == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Descripcion", cursoModel.EspecialidadId);
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", cursoModel.ParaleloId);
            return View(cursoModel);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaInicio,FechaFin,ParaleloId,EspecialidadId")] CursoModel cursoModel)
        {
            if (id != cursoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoModelExists(cursoModel.Id))
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
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Descripcion", cursoModel.EspecialidadId);
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", cursoModel.ParaleloId);
            return View(cursoModel);
        }

        // GET: Curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos
                .Include(c => c.Especialidad)
                .Include(c => c.Paralelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            return View(cursoModel);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoModel = await _context.Cursos.FindAsync(id);
            if (cursoModel != null)
            {
                _context.Cursos.Remove(cursoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoModelExists(int id)
        {
            return _context.Cursos.Any(e => e.Id == id);
        }
    }
}

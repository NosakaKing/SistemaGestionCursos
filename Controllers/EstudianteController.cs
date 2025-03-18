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
    public class EstudianteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudianteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiantes.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudianteModel == null)
            {
                return NotFound();
            }

            return View(estudianteModel);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Telefono,Direccion,Email")] EstudianteModel estudianteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudianteModel);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.Estudiantes.FindAsync(id);
            if (estudianteModel == null)
            {
                return NotFound();
            }
            return View(estudianteModel);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombre,PrimerApellido,SegundoApellido,FechaNacimiento,Telefono,Direccion,Email")] EstudianteModel estudianteModel)
        {
            if (id != estudianteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteModelExists(estudianteModel.Id))
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
            return View(estudianteModel);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudianteModel == null)
            {
                return NotFound();
            }

            return View(estudianteModel);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteModel = await _context.Estudiantes.FindAsync(id);
            if (estudianteModel != null)
            {
                _context.Estudiantes.Remove(estudianteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteModelExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }

        // Método para obtener la lista de estudiantes en formato JSON
        [HttpGet]
        public async Task<IActionResult> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return Json(estudiantes);
        }
        // POST: Estudiante/DeleteEstudianteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstudianteConfirmed(int id)
        {
            var estudianteModel = await _context.Estudiantes.FindAsync(id);
            if (estudianteModel != null)
            {
                _context.Estudiantes.Remove(estudianteModel);
                await _context.SaveChangesAsync();
                return Json(true);
            }
            return Json(false);
        }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGestionCursos.Models;

namespace SistemaGestionCursos.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<IncripcionModel> Incripciones { get; set; }
    public DbSet<CursoModel> Cursos { get; set; }
    public DbSet<EspecialidadModel> Especialidades { get; set; }
    public DbSet<ParaleloModel> Paralelos { get; set; }
    public DbSet<EstudianteModel> Estudiantes { get; set; }

}

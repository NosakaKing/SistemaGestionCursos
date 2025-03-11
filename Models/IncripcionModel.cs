namespace SistemaGestionCursos.Models
{
    public class IncripcionModel
    {
        public int Id { get; set; }
        public DateOnly FechaIncripcion { get; set; }
        public int EstudianteId { get; set; }
        public EstudianteModel? Estudiante { get; set; }
        public int CursoId { get; set; }
        public CursoModel? Curso { get; set; }
    }
}

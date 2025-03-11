using System.ComponentModel.DataAnnotations;

namespace SistemaGestionCursos.Models
{
    public class CursoModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }

        // Relaciones
        public int ParaleloId { get; set; }
        public ParaleloModel? Paralelo { get; set; }
        public int EspecialidadId { get; set; }
        public EspecialidadModel? Especialidad { get; set; }
    }
}

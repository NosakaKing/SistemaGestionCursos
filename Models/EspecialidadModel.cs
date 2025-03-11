using System.ComponentModel.DataAnnotations;

namespace SistemaGestionCursos.Models
{
    public class EspecialidadModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SistemaGestionCursos.Models
{
    public class EstudianteModel
    {
        public int Id { get; set; }
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El primer apellido es requerido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "El segundo apellido es requerido")]
        public string SegundoApellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateOnly FechaNacimiento { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es requerido")]
        public string? Telefono { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; }

    }
}

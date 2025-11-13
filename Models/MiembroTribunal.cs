using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaTitulos.Models
{
    public class MiembroTribunal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        public string Especialidad { get; set; }

        public bool Activo { get; set; } = true;

        // Propiedad de navegación para la relación muchos a muchos
        public virtual ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTitulos.Models
{
    public class Solicitud
    {
        public Solicitud()
        {
            MiembrosTribunal = new HashSet<MiembroTribunal>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        [Display(Name = "Nombre del Estudiante")]
        public string NombreEstudiante { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        public string Carrera { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Solicitud")]
        public DateTime? FechaSolicitud { get; set; }

        public string? Estado { get; set; }

        // Propiedades para la relación con Tutor (HU-DC-02)
        [Display(Name = "Tutor Asignado")]
        public int? TutorId { get; set; }

        [ForeignKey("TutorId")]
        public virtual Tutor? Tutor { get; set; }

        [Display(Name = "Calificación Final")]
        public decimal? CalificacionFinal { get; set; }

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        [Display(Name = "Nombre del Proyecto")]
        public string NombreProyecto { get; set; }

        // Propiedad de navegación para la relación muchos a muchos con MiembroTribunal (HU-DC-03)
        public virtual ICollection<MiembroTribunal> MiembrosTribunal { get; set; }
    }
}

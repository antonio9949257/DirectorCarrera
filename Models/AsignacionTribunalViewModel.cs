using System.Collections.Generic;

namespace SistemaTitulos.Models
{
    public class AsignacionTribunalViewModel
    {
        public Solicitud Solicitud { get; set; }
        public List<MiembroTribunalAsignado> MiembrosDisponibles { get; set; }
    }
    public class MiembroTribunalAsignado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public bool Asignado { get; set; }
    }
}

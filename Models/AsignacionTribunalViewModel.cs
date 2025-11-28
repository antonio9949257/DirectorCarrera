using System.Collections.Generic;

namespace SistemaTitulos.Models
{
    public class AsignacionTribunalViewModel
    {
        public Solicitud Solicitud { get; set; }
        public List<MiembroTribunalAsignado> MiembrosDisponibles { get; set; }
    }
}

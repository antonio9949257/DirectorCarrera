using System.Collections.Generic;

namespace SistemaTitulos.Models
{
    // ViewModel para la vista de asignación de tribunal
    public class AsignacionTribunalViewModel
    {
        public Solicitud Solicitud { get; set; }
        public List<MiembroTribunalAsignado> MiembrosDisponibles { get; set; }
    }

    // Clase auxiliar para representar a un miembro del tribunal en la lista de checkboxes
    public class MiembroTribunalAsignado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public bool Asignado { get; set; }
    }
}

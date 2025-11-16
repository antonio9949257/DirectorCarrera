using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaTitulos.Models;
using System.Collections.Generic;

namespace SistemaTitulos.Models
{
    public class PanelViewModel
    {
        public List<Solicitud> Solicitudes { get; set; }
        public Dictionary<string, int> SolicitudCountsByEstado { get; set; }
        public string SearchString { get; set; }
        public int? TutorId { get; set; }
        public string Estado { get; set; }
        public SelectList TutorIdFilter { get; set; }
        public SelectList EstadoFilter { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SistemaTitulos.Models
{
    public static class EstadosHelper
    {
        public static List<SelectListItem> GetEstadosDisponibles(string estadoActual)
        {
            var lista = new List<SelectListItem>();

            switch (estadoActual)
            {
                case SolicitudEstados.Borrador:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Pendiente, Text = "Pendiente" });
                    break;

                case SolicitudEstados.Pendiente:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Observada, Text = "Observada" });
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Aceptada, Text = "Aceptada" });
                    break;

                case SolicitudEstados.Observada:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Pendiente, Text = "Pendiente" }); // Can go back to Pendiente after corrections
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Aceptada, Text = "Aceptada" });
                    break;

                case SolicitudEstados.Aceptada:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.SinTutor, Text = "Sin Tutor" });
                    break;

                case SolicitudEstados.SinTutor:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.TutorPendiente, Text = "Tutor Pendiente" });
                    lista.Add(new SelectListItem { Value = SolicitudEstados.TutorAsignado, Text = "Tutor Asignado" });
                    break;

                case SolicitudEstados.TutorPendiente:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.TutorAsignado, Text = "Tutor Asignado" });
                    break;

                case SolicitudEstados.TutorAsignado:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.SinTribunal, Text = "Sin Tribunal" });
                    break;

                case SolicitudEstados.SinTribunal:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.TribunalIncompleto, Text = "Tribunal Incompleto" });
                    lista.Add(new SelectListItem { Value = SolicitudEstados.TribunalAsignado, Text = "Tribunal Asignado" });
                    break;

                case SolicitudEstados.TribunalIncompleto:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.TribunalAsignado, Text = "Tribunal Asignado" });
                    break;

                case SolicitudEstados.TribunalAsignado:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.EnProgreso, Text = "En Progreso" });
                    break;

                case SolicitudEstados.EnProgreso:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.SinAvance, Text = "Sin Avance" });
                    break;

                case SolicitudEstados.SinAvance:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.EnSeguimiento, Text = "En Seguimiento" });
                    break;

                case SolicitudEstados.EnSeguimiento:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.ConAvancesActualizados, Text = "Con Avances Actualizados" });
                    break;

                case SolicitudEstados.ConAvancesActualizados:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.EnEvaluacion, Text = "En Evaluación" });
                    break;

                case SolicitudEstados.EnEvaluacion:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.EnEvaluacionDefensaProgramada, Text = "En Evaluación Defensa Programada" });
                    break;

                case SolicitudEstados.EnEvaluacionDefensaProgramada:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Calificada, Text = "Calificada" });
                    break;

                case SolicitudEstados.Calificada:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Finalizado, Text = "Finalizado" });
                    break;

                case SolicitudEstados.Finalizado:
                    lista.Add(new SelectListItem { Value = SolicitudEstados.Archivado, Text = "Archivado" });
                    break;
            }

            return lista;
        }
    }
}

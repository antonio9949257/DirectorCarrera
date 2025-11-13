namespace SistemaTitulos.Models
{
    public static class SolicitudEstados
    {
        // Estados del Proceso de Modalidad de Graduación (Principales)
        public const string Pendiente = "Pendiente";
        public const string Observada = "Observada";
        public const string Aceptada = "Aceptada";
        public const string TutorAsignado = "Tutor Asignado";
        public const string TribunalAsignado = "Tribunal Asignado";
        public const string EnProgreso = "En Progreso";
        public const string EnEvaluacionDefensaProgramada = "En Evaluación / Defensa Programada";
        public const string Finalizado = "Finalizado";
        public const string Archivado = "Archivado";

        // Estados internos de cada Historia de Usuario (HU-DC-01: Gestión de Solicitudes)
        public const string Borrador = "Borrador";

        // Estados internos de cada Historia de Usuario (HU-DC-02: Asignación de Tutor)
        public const string SinTutor = "Sin Tutor";
        public const string TutorPendiente = "Tutor Pendiente";

        // Estados internos de cada Historia de Usuario (HU-DC-03: Asignación de Tribunal)
        public const string SinTribunal = "Sin Tribunal";
        public const string TribunalIncompleto = "Tribunal Incompleto";

        // Estados internos de cada Historia de Usuario (HU-DC-04: Panel de Seguimiento)
        public const string SinAvance = "Sin Avance";
        public const string EnSeguimiento = "En Seguimiento";
        public const string ConAvancesActualizados = "Con Avances Actualizados";

        // Estados internos de cada Historia de Usuario (HU-DC-05: Registro de Calificación y Cierre)
        public const string EnEvaluacion = "En Evaluación";
        public const string Calificada = "Calificada";
    }
}

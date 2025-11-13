# Estado Actual del Proyecto: Sistema de Gestión de Modalidad de Graduación

Este documento resume el estado de desarrollo del proyecto, las funcionalidades implementadas y los pasos a seguir. **Última actualización:** 13 de noviembre de 2025.

## Estado General
El proyecto se encuentra en fase de desarrollo activo. La base de datos está configurada y las HU-DC-01 y HU-DC-02 están completas. La HU-DC-03 está en progreso. Se han realizado mejoras de usabilidad en la interfaz.

---

## Funcionalidades Implementadas

### ✅ HU-DC-01: Gestión de Solicitudes
- **Estado:** Completada.
- **Detalles:** Funcionalidad CRUD operativa para las solicitudes.

### ✅ HU-DC-02: Asignación de Tutor
- **Estado:** Completada.
- **Detalles:** CRUD de Tutores (`/Tutors`) y asignación a solicitudes funcionando.

### 🟡 HU-DC-03: Asignación del Tribunal Calificador
- **Estado:** En Progreso.
- **Detalles Implementados:**
    - CRUD de Miembros de Tribunal (`/MiembrosTribunal`).
    - Lógica de asignación de múltiples jurados a una solicitud mediante checkboxes.
    - Se ha añadido el paquete `QuestPDF` al proyecto en preparación para la generación de documentos.
- **Tareas Pendientes de esta HU:**
    1.  Crear la clase que define la estructura del documento del acta de defensa.
    2.  Crear la acción en el controlador para generar y descargar el archivo PDF.
    3.  Añadir el botón de "Generar Acta" en la vista de detalles de la solicitud.

### ✨ Mejoras de Interfaz de Usuario
- Se han añadido los enlaces de navegación para **"Solicitudes"**, **"Tutores"** y **"Tribunal"** en la barra de navegación principal para un acceso rápido y sencillo.

---

## Tareas y Funcionalidades Pendientes

- **HU-DC-03:** Finalizar la implementación de la generación de PDF (ver desglose arriba).
- **HU-DC-04:** Implementar el **Panel de Seguimiento de Avances** con filtros de búsqueda.
- **HU-DC-05:** Implementar el **Registro de Calificación Final y Cierre de Proceso**.

---

## Cómo Ejecutar la Aplicación

1.  **Asegúrate de que tu instancia de SQL Server esté en ejecución.**
2.  Abre una terminal en la raíz del proyecto.
3.  Ejecuta el siguiente comando:
    ```bash
    dotnet run
    ```
4.  La aplicación estará disponible en la siguiente URL: `http://localhost:5074`

### URLs Directas
- **Gestión de Solicitudes:** [http://localhost:5074/Solicitudes](http://localhost:5074/Solicitudes)
- **Gestión de Tutores:** [http://localhost:5074/Tutors](http://localhost:5074/Tutors)
- **Gestión de Miembros de Tribunal:** [http://localhost:5074/MiembrosTribunal](http://localhost:5074/MiembrosTribunal)

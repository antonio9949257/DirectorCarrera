# README3.md - Technical Overview: Sistema de Gestión de Modalidad de Graduación

This document provides a technical overview of the "Sistema de Gestión de Modalidad de Graduación" project, detailing its current state, implemented features, and technical considerations.

---

## 1. Project Overview

The project is a .NET 8 MVC application designed to manage the graduation modality process. It includes functionalities for managing student requests, assigning tutors and qualifying tribunals, tracking progress, and recording final grades.

---

## 2. Implemented Features (User Stories)

The following User Stories (Historias de Usuario - HU) have been implemented:

### ✅ HU-DC-01: Gestión de Solicitudes
*   **CRUD Operations**: Full Create, Read, Update, Delete (CRUD) functionality for `Solicitud` entities.
*   **State Management**: `Solicitud` entities now utilize a predefined set of static states (`SolicitudEstados`) for better consistency. The `Create` form allows selection of initial states (`Borrador`, `Pendiente`). The `Edit` form allows selection of all defined states.
*   **Data Display**: `NombreProyecto` field is displayed in `Index`, `Panel`, and `Details` views.

### ✅ HU-DC-02: Asignación de Tutor
*   **CRUD Operations**: Full CRUD functionality for `Tutor` entities (via `/Tutors`).
*   **Assignment**: Tutors can be assigned to `Solicitud` entities via the `Edit` form.
*   **Data Seeding**: Initial set of tutors with specific specialties are pre-seeded into the database.

### ✅ HU-DC-03: Asignación del Tribunal Calificador
*   **CRUD Operations**: Full CRUD functionality for `MiembroTribunal` entities (via `/MiembrosTribunal`).
*   **Assignment**: Multiple `MiembroTribunal` can be assigned to a `Solicitud` via checkboxes in the `Edit` form.
*   **PDF Generation**: Functionality to generate and download a PDF "Acta de Defensa" for a `Solicitud` from its details view. The PDF header reflects the institution "I.T. ESCUELA INDUSTRIAL SUPERIOR “Pedro Domingo Murillo”" and "CARRERA DE INFORMÁTICA INDUSTRIAL".
*   **Data Seeding**: Initial set of `MiembroTribunal` are pre-seeded into the database.

### ✅ HU-DC-04: Panel de Seguimiento de Avances
*   **Dedicated View**: A new "Panel de Seguimiento" view (`/Solicitudes/Panel`) provides an overview of all `Solicitud` entities.
*   **Filtering**: Includes filtering options by student name (`searchString`), `Tutor`, and `Estado`.
*   **Navigation**: Accessible via a link in the main navigation bar.

### ✅ HU-DC-05: Registro de Calificación Final y Cierre de Proceso
*   **Model Extension**: The `Solicitud` model now includes a nullable `CalificacionFinal` (decimal) property.
*   **Database Migration**: A migration was created and applied to add `CalificacionFinal` to the database.
*   **UI Integration**: `CalificacionFinal` can be entered/edited in the `Edit` form and is displayed in `Details` and `Panel` views.

---

## 3. Technical Stack

*   **.NET 8 MVC**: Core framework for the web application.
*   **Entity Framework Core**: ORM for database interaction.
    *   `Microsoft.EntityFrameworkCore.SqlServer`: SQL Server provider.
    *   `Microsoft.EntityFrameworkCore.Tools`: For EF Core migrations.
*   **QuestPDF**: Library for generating PDF documents.
*   **Bootstrap**: CSS framework for responsive and modern UI.

---

## 4. Database Migrations

The project uses Entity Framework Core Migrations to manage schema changes. The following migrations have been applied:

*   `InitialCreate`: Initial database schema for `Solicitud`.
*   `AddTutorAndLinkToSolicitud`: Adds `Tutor` entity and links it to `Solicitud`.
*   `AddTribunalAndManyToMany`: Adds `MiembroTribunal` entity and establishes a many-to-many relationship with `Solicitud`.
*   `AddCalificacionFinalToSolicitud`: Adds the `CalificacionFinal` property to the `Solicitud` model.
*   `AddNombreProyectoToSolicitud`: Adds the `NombreProyecto` property to the `Solicitud` model.
*   `MakeFechaSolicitudNullable`: Makes the `FechaSolicitud` property nullable in the `Solicitud` model.

---

## 5. Data Seeding (`DbInitializer.cs`)

The `DbInitializer.cs` class is responsible for seeding initial data into the database upon application startup. It ensures that:

*   All pending migrations are applied (`context.Database.MigrateAsync()`).
*   Existing `Solicitudes`, `MiembroTribunal`, and `Tutor` data are cleared to ensure a fresh seed (for development/testing purposes).
*   Default `MiembroTribunal` entries are created.
*   Default `Tutor` entries with specific specialties are created.
*   A set of sample `Solicitud` entries are created with various states and assigned random tutors.

---

## 6. State Management (`SolicitudEstados.cs`)

A static class `SolicitudEstados.cs` defines all possible states for a `Solicitud` entity, including main process states and internal states related to specific User Stories. This promotes consistency and avoids magic strings.

*   **Main States**: `Pendiente`, `Observada`, `Aceptada`, `Tutor Asignado`, `Tribunal Asignado`, `En Progreso`, `En Evaluación / Defensa Programada`, `Finalizado`, `Archivado`.
*   **Internal States**: `Borrador`, `Sin Tutor`, `Tutor Pendiente`, `Sin Tribunal`, `Tribunal Incompleto`, `Sin Avance`, `En Seguimiento`, `Con Avances Actualizados`, `En Evaluación`, `Calificada`.

---

## 7. How to Run the Application

1.  **Ensure SQL Server is running** and accessible with the connection string configured in `appsettings.json`.
2.  Open a terminal in the project's root directory (`/home/devadam/SistemaTitulos`).
3.  Execute the following command:
    ```bash
    dotnet run
    ```
4.  The application will be available at `http://localhost:5074`.

### Direct URLs:
*   **Gestión de Solicitudes:** `http://localhost:5074/Solicitudes`
*   **Gestión de Tutores:** `http://localhost:5074/Tutors`
*   **Gestión de Miembros de Tribunal:** `http://localhost:5074/MiembrosTribunal`
*   **Panel de Seguimiento:** `http://localhost:5074/Solicitudes/Panel`

---

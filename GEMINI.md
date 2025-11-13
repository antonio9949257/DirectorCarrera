# GEMINI.md - Contexto del Proyecto "Sistema de Gestión de Modalidad de Graduación"

## Estado Actual del Proyecto

Hemos avanzado en la configuración inicial del proyecto .NET 8 MVC:

*   **Proyecto Base:** Se ha inicializado un proyecto .NET 8 MVC (`SistemaTitulos`).
*   **Dependencias:** Se han instalado los paquetes de Entity Framework Core para SQL Server (`Microsoft.EntityFrameworkCore.SqlServer` y `Microsoft.EntityFrameworkCore.Tools` versión 8.0.0).
*   **Modelo `Solicitud`:** Se ha definido el modelo `Solicitud` en `SistemaTitulos/Models/Solicitud.cs` con campos básicos como `Id`, `NombreEstudiante`, `Carrera`, `FechaSolicitud` y `Estado`.
*   **`ApplicationDbContext`:** Se ha creado el contexto de base de datos `ApplicationDbContext` en `SistemaTitulos/Data/ApplicationDbContext.cs`, que incluye un `DbSet` para `Solicitud`.
*   **Configuración de Conexión:** La cadena de conexión a SQL Server se ha configurado en `appsettings.json` bajo `DefaultConnection`, utilizando las credenciales proporcionadas (`User Id=devarmin;Password=armin2DEV9949257`).
*   **Registro del `DbContext`:** El `ApplicationDbContext` se ha registrado en `Program.cs` para la inyección de dependencias.
*   **Generación de CRUD:** Se instaló la herramienta `dotnet-aspnet-codegenerator` y se utilizó para generar automáticamente el `SolicitudesController.cs` y las vistas CRUD (`Create`, `Edit`, `Details`, `Delete`, `Index`) en `Views/Solicitudes/` para el modelo `Solicitud`.

## Próximos Pasos y Tareas Pendientes

El siguiente paso crítico es la configuración de la base de datos mediante migraciones de Entity Framework Core:

1.  **Generar Migración de Base de Datos:**
    *   El comando `dotnet ef migrations add InitialCreate` ha fallado repetidamente debido a problemas con la herramienta `dotnet-ef` (no se encuentra o falla la instalación global).
    *   Se intentó instalar la herramienta global y limpiar la caché de NuGet sin éxito.
    *   Se intentó ejecutar el comando a través de `dotnet run --project SistemaTitulos.csproj -- ef migrations add InitialCreate`, pero la ejecución fue cancelada.
    *   **Acción Requerida:** Necesitamos resolver el problema con la ejecución de los comandos `dotnet ef` para poder crear la migración inicial que definirá la estructura de la tabla `Solicitudes` en la base de datos.

2.  **Aplicar Migraciones a la Base de Datos:**
    *   Una vez que la migración `InitialCreate` sea generada, deberá aplicarse a la base de datos SQL Server usando `dotnet ef database update`.

3.  **Verificar Configuración de SQL Server:**
    *   El usuario ha confirmado que tiene SQL Server instalado de forma nativa. La cadena de conexión asume `Server=localhost` y una base de datos llamada `SistemaTitulosDB`. Es crucial asegurarse de que la instancia de SQL Server esté en ejecución y sea accesible, y que la base de datos `SistemaTitulosDB` pueda ser creada o ya exista.

4.  **Ejecutar la Aplicación:**
    *   Después de que la base de datos esté configurada y actualizada, la aplicación podrá ejecutarse (`dotnet run`) y se podrá acceder al CRUD básico de `Solicitudes` a través del navegador.

5.  **Implementación de Historias de Usuario Restantes:**
    *   Una vez que el módulo básico de `Solicitud` esté funcional, se procederá con la implementación de las demás historias de usuario (HU-DC-02: Asignación de tutor, HU-DC-03: Asignación de tribunal, HU-DC-04: Panel de seguimiento, HU-DC-05: Calificación y cierre) según el plan de sprints.

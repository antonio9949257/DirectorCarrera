# Sistema de Gestión de Modalidad de Graduación

## Descripción del Proyecto

Este proyecto es una aplicación web desarrollada con el framework .NET 8 MVC, diseñada para automatizar y digitalizar el proceso académico de titulación de estudiantes universitarios. El sistema centraliza las operaciones que el Director de Carrera realiza durante el proceso de graduación, incluyendo el registro y validación de solicitudes, asignación de tutores y tribunales, seguimiento de proyectos, y registro de calificaciones finales.

La aplicación utiliza una base de datos SQL Server y está diseñada para ejecutarse en entornos Linux, aprovechando la compatibilidad multiplataforma de .NET 8.

## Tecnologías Utilizadas

*   **Framework:** .NET 8 MVC
*   **Base de Datos:** Microsoft SQL Server
*   **ORM:** Entity Framework Core
*   **UI:** Bootstrap (para un diseño responsivo y limpio)

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

*   **.NET 8.0 SDK** o superior.
*   **Microsoft SQL Server** (instalado localmente o accesible desde tu máquina).
*   **Visual Studio Code** (recomendado para desarrollo).
*   **dotnet-aspnet-codegenerator** (herramienta global para scaffolding).
*   **dotnet-ef** (herramienta global para migraciones de Entity Framework Core).

## Configuración y Ejecución del Proyecto

Sigue estos pasos para configurar y ejecutar el proyecto en tu entorno local:

1.  **Clonar el Repositorio (si aplica):**
    ```bash
    git clone <URL_DEL_REPOSITORIO>
    cd SistemaTitulos
    ```

2.  **Configurar la Cadena de Conexión a la Base de Datos:**
    Abre el archivo `appsettings.json` en la raíz del proyecto y verifica la sección `ConnectionStrings`. Asegúrate de que la cadena de conexión `DefaultConnection` apunte a tu instancia de SQL Server.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=SistemaTitulosDB;User Id=devarmin;Password=armin2DEV9949257;TrustServerCertificate=True;"
      },
      // ... otras configuraciones
    }
    ```
    **Importante:** Ajusta `Server`, `Database`, `User Id` y `Password` según la configuración de tu SQL Server. `TrustServerCertificate=True` es a menudo necesario para entornos de desarrollo.

3.  **Instalar Herramientas Globales (si no están instaladas):**
    ```bash
    dotnet tool install -g dotnet-aspnet-codegenerator
    dotnet tool install --global dotnet-ef
    ```
    *Nota: Si tienes problemas con la instalación de `dotnet-ef`, consulta la sección de resolución de problemas en `GEMINI.md`.*

4.  **Aplicar Migraciones de Base de Datos:**
    Desde el directorio raíz del proyecto (`SistemaTitulos`), ejecuta los siguientes comandos para crear y aplicar las migraciones de la base de datos:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```
    Estos comandos crearán la base de datos `SistemaTitulosDB` (si no existe) y la tabla `Solicitudes` con el esquema definido en el modelo `Solicitud`.

5.  **Ejecutar la Aplicación:**
    Una vez que las migraciones se hayan aplicado correctamente, puedes iniciar la aplicación:

    ```bash
    dotnet run
    ```
    La aplicación se iniciará y estará accesible, por lo general, en `https://localhost:5001` o `http://localhost:5000`. Abre tu navegador y navega a la URL para ver la aplicación en funcionamiento.

## Módulos Implementados (Sprint 1)

Hasta ahora, se ha implementado el módulo básico de gestión de solicitudes:

*   **Gestión de Solicitudes (HU-DC-01):** Se ha generado un CRUD completo para el modelo `Solicitud`, permitiendo crear, leer, actualizar y eliminar registros de solicitudes de titulación. Puedes acceder a este módulo navegando a `/Solicitudes` en la aplicación.

## Próximos Pasos

El desarrollo continuará con la implementación de las siguientes historias de usuario:

*   **HU-DC-02:** Asignación de tutor
*   **HU-DC-03:** Asignación de tribunal
*   **HU-DC-04:** Panel de seguimiento
*   **HU-DC-05:** Calificación final y cierre

Para más detalles sobre el estado actual y los problemas conocidos, consulta el archivo `GEMINI.md`.

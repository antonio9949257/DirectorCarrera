# Sistema de Gestión de Modalidad de Graduación

## Descripción del Proyecto

Este proyecto es una aplicación web desarrollada con el framework .NET 8 MVC, diseñada para automatizar y digitalizar el proceso académico de titulación de estudiantes universitarios. El sistema centraliza las operaciones que el Director de Carrera realiza durante el proceso de graduación, incluyendo el registro y validación de solicitudes, asignación de tutores y tribunales, seguimiento de proyectos, y registro de calificaciones finales.

La aplicación utiliza una base de datos SQL Server y está diseñada para ejecutarse en entornos Linux, aprovechando la compatibilidad multiplataforma de .NET 8.

## Tecnologías Utilizadas

*   **Framework:** .NET 8 MVC
*   **Base de Datos:** Microsoft SQL Server
*   **ORM:** Entity Framework Core
*   **Generación de PDF:** QuestPDF
*   **UI:** Bootstrap (para un diseño responsivo y moderno)

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

*   **.NET 8.0 SDK** o superior.
*   **Microsoft SQL Server** (instalado localmente o accesible desde tu máquina).
*   **Visual Studio Code** (recomendado para desarrollo) o un IDE compatible.
*   **dotnet-aspnet-codegenerator** (herramienta global para scaffolding).
*   **sqlcmd** (herramienta de línea de comandos para interactuar con SQL Server en Linux).

## Configuración y Ejecución del Proyecto

Sigue estos pasos para configurar y ejecutar el proyecto en tu entorno local:

1.  **Clonar el Repositorio:**
    ```bash
    git clone <URL_DEL_REPOSITORIO>
    cd DirectorCarrera
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

4.  **Configurar la Base de Datos y Cargar Datos Iniciales (Seeding):**
    Primero, aplica las migraciones de Entity Framework Core para crear la estructura de la base de datos. Luego, carga los datos iniciales utilizando el script SQL generado.

    ```bash
    # Desde el directorio raíz del proyecto (DirectorCarrera)
    dotnet ef database update

    # Cargar datos iniciales usando el script SQL
    sqlcmd -S localhost -d SistemaTitulosDB -U devarmin -P"armin2DEV9949257" -i ./seed_data.sql
    ```
    **Nota:** El script `seed_data.sql` limpiará las tablas `MiembroTribunalSolicitud`, `Solicitudes`, `MiembroTribunal` y `Tutor` antes de insertar los nuevos datos.

5.  **Ejecutar la Aplicación:**
    Una vez que la base de datos esté configurada y los datos iniciales cargados, puedes iniciar la aplicación:

    ```bash
    dotnet run
    ```
    La aplicación se iniciará y estará accesible, por lo general, en `https://localhost:5001` o `http://localhost:5000`. Abre tu navegador y navega a la URL para ver la aplicación en funcionamiento.

## Estructura del Proyecto (Archivos Clave)

*   **`DirectorCarrera.sln`**: El archivo de solución de Visual Studio. Organiza uno o más proyectos relacionados (como `SistemaTitulos.csproj`) en un solo contenedor, facilitando la gestión y compilación conjunta.
*   **`SistemaTitulos.csproj`**: El archivo de proyecto de C#. Define todos los archivos, recursos, referencias a paquetes NuGet y las instrucciones de compilación para el proyecto `SistemaTitulos`.
*   **`Models/`**: Contiene las clases que representan las entidades de la base de datos (ej. `Solicitud.cs`, `Tutor.cs`, `MiembroTribunal.cs`) y ViewModels (`PanelViewModel.cs`, `AsignacionTribunalViewModel.cs`).
*   **`Controllers/`**: Contiene los controladores MVC que manejan la lógica de las solicitudes HTTP y la interacción con los modelos y las vistas.
*   **`Views/`**: Contiene los archivos `.cshtml` que definen la interfaz de usuario de la aplicación.
*   **`Data/`**: Contiene el `ApplicationDbContext.cs` (contexto de la base de datos) y la carpeta `SeedData` con `DbInitializer.cs`.
*   **`Migrations/`**: Contiene los archivos generados por Entity Framework Core para gestionar los cambios en el esquema de la base de datos.
*   **`wwwroot/`**: Contiene archivos estáticos como CSS, JavaScript e imágenes.

## Módulos y Funcionalidades Implementadas (Historias de Usuario)

### ✅ HU-DC-01: Gestión de Solicitudes
*   **Operaciones CRUD**: Funcionalidad completa de Crear, Leer, Actualizar, Eliminar (CRUD) para las entidades `Solicitud`.
*   **Gestión de Estados**: Las entidades `Solicitud` utilizan un conjunto predefinido de estados estáticos (`SolicitudEstados`) para una mayor consistencia.

### ✅ HU-DC-02: Asignación de Tutor
*   **Operaciones CRUD**: Funcionalidad CRUD completa para las entidades `Tutor` (a través de `/Tutors`).
*   **Asignación**: Los tutores pueden asignarse a las entidades `Solicitud` a través del formulario `Edit`.

### ✅ HU-DC-03: Asignación del Tribunal Calificador
*   **Operaciones CRUD**: Funcionalidad CRUD completa para las entidades `MiembroTribunal` (a través de `/MiembrosTribunal`).
*   **Asignación**: Se pueden asignar múltiples `MiembroTribunal` a una `Solicitud` mediante casillas de verificación en el formulario `Edit`.
*   **Generación de PDF**: Funcionalidad para generar y descargar un "Acta de Defensa" en PDF para una `Solicitud` desde su vista de detalles.

### ✅ HU-DC-04: Panel de Seguimiento de Avances
*   **Vista Dedicada**: Una nueva vista "Panel de Seguimiento" (`/Solicitudes/Panel`) proporciona una visión general de todas las entidades `Solicitud`.
*   **Filtrado**: Incluye opciones de filtrado por nombre de estudiante (`searchString`), `Tutor` y `Estado`.
*   **Tarjetas de Estado**: Se han añadido tarjetas informativas que muestran el recuento de solicitudes por cada estado (ej. Aprobados, En Receso, No Aprobados).

### ✅ HU-DC-05: Registro de Calificación Final y Cierre de Proceso
*   **Extensión del Modelo**: El modelo `Solicitud` ahora incluye una propiedad `CalificacionFinal` (decimal, anulable).
*   **Integración de UI**: `CalificacionFinal` se puede introducir/editar en el formulario `Edit` y se muestra en las vistas `Details` y `Panel`.

## Cambios y Mejoras Recientes (Realizados con Gemini)

Durante el desarrollo asistido por Gemini, se han implementado las siguientes mejoras y correcciones:

*   **Generación de Script SQL para Carga Inicial de Datos**: Se creó `seed_data.sql` para permitir la carga inicial de datos de `MiembroTribunal`, `Tutor` y `Solicitud` directamente en la base de datos mediante `sqlcmd`, evitando la necesidad de ejecutar código C# para el seeding inicial.
*   **Limpieza del `DbInitializer`**: El archivo `Data/SeedData/DbInitializer.cs` fue modificado para eliminar los bloques de código que contenían datos de ejemplo (`new MiembroTribunal`, `new Tutor`, `new Solicitud`) y las llamadas a `RemoveRange`. Ahora, `DbInitializer` solo se encarga de aplicar las migraciones pendientes, sin borrar ni insertar datos de forma programática.
*   **Mejoras en el Panel de Seguimiento de Avances**:
    *   Se creó `Models/PanelViewModel.cs` para encapsular los datos necesarios para la vista del panel.
    *   El controlador `SolicitudesController.cs` fue actualizado para calcular los recuentos de solicitudes por estado y pasar esta información a la vista a través de `PanelViewModel`.
    *   La vista `Views/Solicitudes/Panel.cshtml` fue modificada para mostrar estos recuentos en tarjetas de Bootstrap, proporcionando una visión rápida del estado general de las solicitudes.
*   **Ajustes de Estilo Global (Tema Oscuro)**:
    *   El archivo `wwwroot/css/site.css` fue modificado para establecer un fondo negro (`#000000`) y texto blanco (`color: white;`) para el `body` de la aplicación.
    *   La barra de navegación en `Views/Shared/_Layout.cshtml` fue actualizada a `navbar-dark bg-dark` con `text-white` para los enlaces, adaptándose al tema oscuro.
*   **Ajustes de Estilo en Tablas**:
    *   Se añadió la clase `text-white` a todas las tablas en `Views/Solicitudes/Panel.cshtml`, `Views/Solicitudes/Index.cshtml`, `Views/Tutors/Index.cshtml` y `Views/MiembrosTribunal/Index.cshtml` para asegurar que el texto sea blanco.
    *   Se añadió una regla CSS en `wwwroot/css/site.css` (`.table.text-white th, .table.text-white td { color: white; }`) para garantizar que el texto de las celdas y encabezados de las tablas sea blanco, incluso en filas alternas (`table-striped`).
    *   Se configuró un efecto de resaltado dorado (`#FFD700`) con texto negro (`color: black;`) para las filas de la tabla al pasar el cursor (`.table-hover tbody tr:hover`) en `wwwroot/css/site.css`.
*   **Ajustes de Estilo en el Formulario de Filtro del Panel**:
    *   El `card` que contiene el formulario de filtro en `Views/Solicitudes/Panel.cshtml` fue actualizado con las clases `bg-dark` y `text-white`.
    *   Se añadieron reglas CSS en `wwwroot/css/site.css` para estilizar los controles de formulario (`.form-control`) dentro de un contexto oscuro, dándoles un fondo oscuro sutil y texto blanco.

## Próximos Pasos y Tareas Pendientes

El desarrollo continuará con la implementación de las siguientes historias de usuario y mejoras:

*   **Finalizar HU-DC-03**: Asegurar que la generación de PDF sea completamente funcional y esté integrada.
*   **Mejoras en el Panel de Seguimiento**: Posibles adiciones de gráficos o visualizaciones más avanzadas.
*   **Refinamiento de UI/UX**: Continuar mejorando la experiencia del usuario y la estética general de la aplicación.

## Contacto

Para cualquier consulta o contribución, por favor contacta al equipo de desarrollo.
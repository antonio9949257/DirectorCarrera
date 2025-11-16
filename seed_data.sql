SET NOCOUNT ON;

DELETE FROM MiembroTribunalSolicitud;
DELETE FROM Solicitudes;
DELETE FROM MiembroTribunal;
DELETE FROM Tutor;

PRINT 'Existing data cleared.';

PRINT 'Inserting MiembroTribunal data...';

INSERT INTO MiembroTribunal (NombreCompleto, Especialidad, Activo) VALUES (N'Dr. Juan Pérez', N'Ingeniería de Software', 1);
INSERT INTO MiembroTribunal (NombreCompleto, Especialidad, Activo) VALUES (N'MSc. Ana García', N'Bases de Datos', 1);
INSERT INTO MiembroTribunal (NombreCompleto, Especialidad, Activo) VALUES (N'Ing. Luis Ramirez', N'Redes', 1);
INSERT INTO MiembroTribunal (NombreCompleto, Especialidad, Activo) VALUES (N'Dra. Laura Torres', N'Inteligencia Artificial', 1);

PRINT 'MiembroTribunal data inserted.';

PRINT 'Inserting Tutor data...';

INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Adrián Quisbert', N'Programación, IA y Robótica', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Alfredo Laura', N'Emprendimiento, IA y Robótica', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Ciprián Huanca', N'Álgebra Lineal', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Crispín Quispe', N'Electrónica, Física Aplicada', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Doris Poma', N'Electrónica, Tecnología Web', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Edgar Condori', N'Electrónica, Bases de Datos', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Edgar Mendoza', N'Electrónica, Ing. Software, Apps Industriales', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Efraín García', N'Sistemas Operativos, Telemática', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Erika Cruz', N'Tecnología Web', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Fernando Choque', N'Telemática, Mant. Sistemas Industriales', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Grover Magueño', N'Mant. Sistemas Industriales, Ing. Software', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Hugo Choque', N'Programación, Electrónica, Control y Automatización', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Irene Vedia', N'Programación, Telemática', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Jeannette Mamani', N'Bases de Datos, Tecnología Web', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Juan C. Quispe', N'Gestión y Seguridad en Redes', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Juan Cazana', N'Inglés Técnico, Programación, Taller de Graduación', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Julia Zenteno', N'Programación, Física Aplicada, Apps Móviles', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Lourdes Averanga', N'Sistemas Digitales, Electrónica, Telemática', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Luis Cazorla', N'Medidas y Circuitos Electrónicos, Control y Automatización', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'María Kesocala', N'Inglés Técnico', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Pablo Osco', N'Programación, Bases de Datos, Dibujo CAD', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Peregrina Carazas', N'Programación, Bases de Datos', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Renato Zenteno', N'Electrotecnia Industrial, IA y Robótica', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Ricardo Gottret', N'Telemática', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Roberta Mallcu', N'Tecnología Web', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Rosario Laura', N'Inglés Técnico', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Rudy Cuenca', N'Sistemas Operativos, IA y Robótica', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Santiago Tito', N'Medidas y Circuitos Electrónicos', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Ubaldino Alcon', N'Medidas y Circuitos Electrónicos, Electrónica', 1);
INSERT INTO Tutor (NombreCompleto, Especialidad, Activo) VALUES (N'Yvan López', N'Electrónica, Control y Automatización', 1);

PRINT 'Tutor data inserted.';

PRINT 'Inserting Solicitudes data...';

INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Gherald Gherson Maydana Melendrez', N'Informática Industrial', '2025-10-16 00:00:00', N'Pendiente', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Nemuel Quispe Lopez', N'Informática Industrial', '2025-10-16 00:00:00', N'Observada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Melany Miroslava Maydana Melendrez', N'Informática Industrial', '2025-10-16 00:00:00', N'Aceptada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Raquel Adriana Blanco Contreras', N'Informática Industrial', '2025-10-16 00:00:00', N'TutorAsignado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Balkis Stephanie Chavez Duran', N'Informática Industrial', '2025-10-16 00:00:00', N'TribunalAsignado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Franz Quispe Huanca', N'Informática Industrial', '2025-10-16 00:00:00', N'EnProgreso', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Alvaro Ali Cordero', N'Informática Industrial', '2025-10-16 00:00:00', N'EnEvaluacionDefensaProgramada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Carlos Brayan Calle Mamani', N'Informática Industrial', '2025-10-16 00:00:00', N'Finalizado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Iván Vladimir Mendizabal Camargo', N'Informática Industrial', '2025-10-16 00:00:00', N'Archivado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Bryan Israel Troncoso Mamani', N'Informática Industrial', '2025-10-16 00:00:00', N'Pendiente', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Ignacio Almanza Mamani', N'Informática Industrial', '2025-10-16 00:00:00', N'Observada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Marcos Adalid Illanes Quispe', N'Informática Industrial', '2025-10-16 00:00:00', N'Aceptada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Yamir Cleto Huallpa Prieto', N'Informática Industrial', '2025-10-16 00:00:00', N'TutorAsignado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Cristian Enrique Mamani Cutile', N'Informática Industrial', '2025-10-16 00:00:00', N'TribunalAsignado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Wara Ortiz Quispe', N'Informática Industrial', '2025-10-16 00:00:00', N'EnProgreso', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Abad Gonzalo Escobar Laura', N'Informática Industrial', '2025-10-16 00:00:00', N'EnEvaluacionDefensaProgramada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Jhosimar Wilfredo Mamani Quisbert', N'Informática Industrial', '2025-10-16 00:00:00', N'Finalizado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Ruben Condori', N'Informática Industrial', '2025-10-16 00:00:00', N'Archivado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Wilmer Mauricio Apaza Laurente', N'Informática Industrial', '2025-10-16 00:00:00', N'Pendiente', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Grover Quispe López', N'Informática Industrial', '2025-10-16 00:00:00', N'Observada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Alexander Mamani Mamani', N'Informática Industrial', '2025-10-16 00:00:00', N'Aceptada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Jose Kadyr Choque Orellana', N'Informática Industrial', '2025-10-16 00:00:00', N'TutorAsignado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Armin Daniel Antonio Mendieta', N'Informática Industrial', '2025-10-16 00:00:00', N'TribunalAsignado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Deyvid Yamil Quino Pari', N'Informática Industrial', '2025-10-16 00:00:00', N'EnProgreso', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Kevin Mamani Poma', N'Informática Industrial', '2025-10-16 00:00:00', N'EnEvaluacionDefensaProgramada', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Deymar Fernando Cuevas Alconini', N'Informática Industrial', '2025-10-16 00:00:00', N'Finalizado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Juan Jose Casablanca Sinani', N'Informática Industrial', '2025-10-16 00:00:00', N'Archivado', N'Sistema de Gestión de Modalidades de Graduación', NULL);
INSERT INTO Solicitudes (NombreEstudiante, Carrera, FechaSolicitud, Estado, NombreProyecto, TutorId) VALUES (N'Ivan Franklin Lazo Bernabe', N'Informática Industrial', '2025-10-16 00:00:00', N'Pendiente', N'Sistema de Gestión de Modalidades de Graduación', NULL);

PRINT 'Solicitudes data inserted.';

PRINT 'Data seeding complete.';

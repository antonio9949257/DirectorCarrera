using SistemaTitulos.Data;
using SistemaTitulos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Add this using statement

namespace SistemaTitulos.Data.SeedData
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Clear existing data in correct order to avoid foreign key conflicts
            if (context.Solicitudes.Any())
            {
                context.Solicitudes.RemoveRange(context.Solicitudes);
            }
            if (context.MiembroTribunal.Any())
            {
                context.MiembroTribunal.RemoveRange(context.MiembroTribunal);
            }
            if (context.Tutor.Any())
            {
                context.Tutor.RemoveRange(context.Tutor);
            }
            await context.SaveChangesAsync(); // Save changes after clearing all related data

            // Seed MiembroTribunal
            if (!context.MiembroTribunal.Any())
            {
                var miembrosTribunal = new MiembroTribunal[]
                {
                    new MiembroTribunal{NombreCompleto="Dr. Juan Pérez", Especialidad="Ingeniería de Software", Activo=true},
                    new MiembroTribunal{NombreCompleto="MSc. Ana García", Especialidad="Bases de Datos", Activo=true},
                    new MiembroTribunal{NombreCompleto="Ing. Luis Ramirez", Especialidad="Redes", Activo=true},
                    new MiembroTribunal{NombreCompleto="Dra. Laura Torres", Especialidad="Inteligencia Artificial", Activo=true}
                };
                foreach (var m in miembrosTribunal)
                {
                    context.MiembroTribunal.Add(m);
                }
                await context.SaveChangesAsync();
            }


            // Seed MiembroTribunal
            if (!context.MiembroTribunal.Any())
            {
                var miembrosTribunal = new MiembroTribunal[]
                {
                    new MiembroTribunal{NombreCompleto="Dr. Juan Pérez", Especialidad="Ingeniería de Software", Activo=true},
                    new MiembroTribunal{NombreCompleto="MSc. Ana García", Especialidad="Bases de Datos", Activo=true},
                    new MiembroTribunal{NombreCompleto="Ing. Luis Ramirez", Especialidad="Redes", Activo=true},
                    new MiembroTribunal{NombreCompleto="Dra. Laura Torres", Especialidad="Inteligencia Artificial", Activo=true}
                };
                foreach (var m in miembrosTribunal)
                {
                    context.MiembroTribunal.Add(m);
                }
                await context.SaveChangesAsync();
            }


            // Seed MiembroTribunal
            if (!context.MiembroTribunal.Any())
            {
                var miembrosTribunal = new MiembroTribunal[]
                {
                    new MiembroTribunal{NombreCompleto="Dr. Juan Pérez", Especialidad="Ingeniería de Software", Activo=true},
                    new MiembroTribunal{NombreCompleto="MSc. Ana García", Especialidad="Bases de Datos", Activo=true},
                    new MiembroTribunal{NombreCompleto="Ing. Luis Ramirez", Especialidad="Redes", Activo=true},
                    new MiembroTribunal{NombreCompleto="Dra. Laura Torres", Especialidad="Inteligencia Artificial", Activo=true}
                };
                foreach (var m in miembrosTribunal)
                {
                    context.MiembroTribunal.Add(m);
                }
                await context.SaveChangesAsync();
            }


            // Seed Tutors
            if (!context.Tutor.Any())
            {
                var tutors = new Tutor[]
                {
                    new Tutor{NombreCompleto="Adrián Quisbert", Especialidad="Programación, IA y Robótica", Activo = true},
                    new Tutor{NombreCompleto="Alfredo Laura", Especialidad="Emprendimiento, IA y Robótica", Activo = true},
                    new Tutor{NombreCompleto="Ciprián Huanca", Especialidad="Álgebra Lineal", Activo = true},
                    new Tutor{NombreCompleto="Crispín Quispe", Especialidad="Electrónica, Física Aplicada", Activo = true},
                    new Tutor{NombreCompleto="Doris Poma", Especialidad="Electrónica, Tecnología Web", Activo = true},
                    new Tutor{NombreCompleto="Edgar Condori", Especialidad="Electrónica, Bases de Datos", Activo = true},
                    new Tutor{NombreCompleto="Edgar Mendoza", Especialidad="Electrónica, Ing. Software, Apps Industriales", Activo = true},
                    new Tutor{NombreCompleto="Efraín García", Especialidad="Sistemas Operativos, Telemática", Activo = true},
                    new Tutor{NombreCompleto="Erika Cruz", Especialidad="Tecnología Web", Activo = true},
                    new Tutor{NombreCompleto="Fernando Choque", Especialidad="Telemática, Mant. Sistemas Industriales", Activo = true},
                    new Tutor{NombreCompleto="Grover Magueño", Especialidad="Mant. Sistemas Industriales, Ing. Software", Activo = true},
                    new Tutor{NombreCompleto="Hugo Choque", Especialidad="Programación, Electrónica, Control y Automatización", Activo = true},
                    new Tutor{NombreCompleto="Irene Vedia", Especialidad="Programación, Telemática", Activo = true},
                    new Tutor{NombreCompleto="Jeannette Mamani", Especialidad="Bases de Datos, Tecnología Web", Activo = true},
                    new Tutor{NombreCompleto="Juan C. Quispe", Especialidad="Gestión y Seguridad en Redes", Activo = true},
                    new Tutor{NombreCompleto="Juan Cazana", Especialidad="Inglés Técnico, Programación, Taller de Graduación", Activo = true},
                    new Tutor{NombreCompleto="Julia Zenteno", Especialidad="Programación, Física Aplicada, Apps Móviles", Activo = true},
                    new Tutor{NombreCompleto="Lourdes Averanga", Especialidad="Sistemas Digitales, Electrónica, Telemática", Activo = true},
                    new Tutor{NombreCompleto="Luis Cazorla", Especialidad="Medidas y Circuitos Electrónicos, Control y Automatización", Activo = true},
                    new Tutor{NombreCompleto="María Kesocala", Especialidad="Inglés Técnico", Activo = true},
                    new Tutor{NombreCompleto="Pablo Osco", Especialidad="Programación, Bases de Datos, Dibujo CAD", Activo = true},
                    new Tutor{NombreCompleto="Peregrina Carazas", Especialidad="Programación, Bases de Datos", Activo = true},
                    new Tutor{NombreCompleto="Renato Zenteno", Especialidad="Electrotecnia Industrial, IA y Robótica", Activo = true},
                    new Tutor{NombreCompleto="Ricardo Gottret", Especialidad="Telemática", Activo = true},
                    new Tutor{NombreCompleto="Roberta Mallcu", Especialidad="Tecnología Web", Activo = true},
                    new Tutor{NombreCompleto="Rosario Laura", Especialidad="Inglés Técnico", Activo = true},
                    new Tutor{NombreCompleto="Rudy Cuenca", Especialidad="Sistemas Operativos, IA y Robótica", Activo = true},
                    new Tutor{NombreCompleto="Santiago Tito", Especialidad="Medidas y Circuitos Electrónicos", Activo = true},
                    new Tutor{NombreCompleto="Ubaldino Alcon", Especialidad="Medidas y Circuitos Electrónicos, Electrónica", Activo = true},
                    new Tutor{NombreCompleto="Yvan López", Especialidad="Electrónica, Control y Automatización", Activo = true}
                };

                foreach (Tutor t in tutors)
                {
                    context.Tutor.Add(t);
                }
                await context.SaveChangesAsync();
            }

            // Seed Solicitudes
            if (!context.Solicitudes.Any())
            {
                var allTutors = await context.Tutor.ToListAsync();
                var random = new Random();

                var estadosDisponibles = new List<string>
                {
                    SolicitudEstados.Pendiente,
                    SolicitudEstados.Observada,
                    SolicitudEstados.Aceptada,
                    SolicitudEstados.TutorAsignado,
                    SolicitudEstados.TribunalAsignado,
                    SolicitudEstados.EnProgreso,
                    SolicitudEstados.EnEvaluacionDefensaProgramada,
                    SolicitudEstados.Finalizado,
                    SolicitudEstados.Archivado
                };

                var solicitudes = new Solicitud[]
                {
                    new Solicitud { NombreEstudiante = "Gherald Gherson Maydana Melendrez", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Pendiente, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Nemuel Quispe Lopez", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Observada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Melany Miroslava Maydana Melendrez", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Aceptada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Raquel Adriana Blanco Contreras", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.TutorAsignado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Balkis Stephanie Chavez Duran", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.TribunalAsignado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Franz Quispe Huanca", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.EnProgreso, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Alvaro Ali Cordero", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.EnEvaluacionDefensaProgramada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Carlos Brayan Calle Mamani", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Finalizado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Iván Vladimir Mendizabal Camargo", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Archivado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Bryan Israel Troncoso Mamani", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Pendiente, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Ignacio Almanza Mamani", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Observada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Marcos Adalid Illanes Quispe", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Aceptada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Yamir Cleto Huallpa Prieto", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.TutorAsignado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Cristian Enrique Mamani Cutile", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.TribunalAsignado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Wara Ortiz Quispe", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.EnProgreso, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Abad Gonzalo Escobar Laura", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.EnEvaluacionDefensaProgramada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Jhosimar Wilfredo Mamani Quisbert", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Finalizado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Ruben Condori", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Archivado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Wilmer Mauricio Apaza Laurente", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Pendiente, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Grover Quispe López", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Observada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Alexander Mamani Mamani", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Aceptada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Jose Kadyr Choque Orellana", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.TutorAsignado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Armin Daniel Antonio Mendieta", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.TribunalAsignado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Deyvid Yamil Quino Pari", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.EnProgreso, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Kevin Mamani Poma", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.EnEvaluacionDefensaProgramada, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Deymar Fernando Cuevas Alconini", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Finalizado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Juan Jose Casablanca Sinani", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Archivado, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id },
                    new Solicitud { NombreEstudiante = "Ivan Franklin Lazo Bernabe", Carrera = "Informática Industrial", FechaSolicitud = DateTime.Parse("2025-10-16"), Estado = SolicitudEstados.Pendiente, NombreProyecto = "Sistema de Gestión de Modalidades de Graduación", TutorId = allTutors[random.Next(allTutors.Count)].Id }
                };

                foreach (var s in solicitudes)
                {
                    context.Solicitudes.Add(s);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}

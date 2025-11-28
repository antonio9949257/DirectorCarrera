using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTitulos.Data;
using SistemaTitulos.Models;
using SistemaTitulos.Documents;
using QuestPDF.Fluent;

namespace SistemaTitulos.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Solicitudes.Include(s => s.Tutor);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Panel(string searchString, int? tutorId, string estado)
        {
            var allSolicitudes = await _context.Solicitudes.ToListAsync();
            var solicitudCountsByEstado = allSolicitudes
                .GroupBy(s => s.Estado)
                .ToDictionary(g => g.Key, g => g.Count());

            var solicitudesQuery = from s in _context.Solicitudes
                                   .Include(s => s.Tutor)
                                   .Include(s => s.MiembrosTribunal)
                                   select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                solicitudesQuery = solicitudesQuery.Where(s => s.NombreEstudiante.Contains(searchString));
            }

            if (tutorId.HasValue)
            {
                solicitudesQuery = solicitudesQuery.Where(s => s.TutorId == tutorId.Value);
            }

            if (!String.IsNullOrEmpty(estado))
            {
                solicitudesQuery = solicitudesQuery.Where(s => s.Estado == estado);
            }

            var estadosList = new List<SelectListItem>
            {
                new SelectListItem { Value = SolicitudEstados.Pendiente, Text = "Pendiente" },
                new SelectListItem { Value = SolicitudEstados.Observada, Text = "Observada" },
                new SelectListItem { Value = SolicitudEstados.Aceptada, Text = "Aceptada" },
                new SelectListItem { Value = SolicitudEstados.TutorAsignado, Text = "Tutor Asignado" },
                new SelectListItem { Value = SolicitudEstados.TribunalAsignado, Text = "Tribunal Asignado" },
                new SelectListItem { Value = SolicitudEstados.EnProgreso, Text = "En Progreso" },
                new SelectListItem { Value = SolicitudEstados.EnEvaluacionDefensaProgramada, Text = "En Evaluación / Defensa Programada" },
                new SelectListItem { Value = SolicitudEstados.Finalizado, Text = "Finalizado" },
                new SelectListItem { Value = SolicitudEstados.Archivado, Text = "Archivado" }
            };

            var viewModel = new PanelViewModel
            {
                Solicitudes = await solicitudesQuery.ToListAsync(),
                SolicitudCountsByEstado = solicitudCountsByEstado,
                SearchString = searchString,
                TutorId = tutorId,
                Estado = estado,
                TutorIdFilter = new SelectList(await _context.Tutor.ToListAsync(), "Id", "NombreCompleto", tutorId),
                EstadoFilter = new SelectList(estadosList, "Value", "Text", estado)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes
                .Include(s => s.Tutor)
                .Include(s => s.MiembrosTribunal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        public async Task<IActionResult> GenerarActaPDF(int id)
        {
            var solicitud = await _context.Solicitudes
                .Include(s => s.Tutor)
                .Include(s => s.MiembrosTribunal)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (solicitud == null)
            {
                return NotFound();
            }

            var document = new ActaDefensaDocument(solicitud);
            var pdfBytes = document.GeneratePdf();

            return File(pdfBytes, "application/pdf", $"Acta_Defensa_{solicitud.NombreEstudiante}.pdf");
        }

        public async Task<IActionResult> GenerarActaDesignacionTutorPDF(int id)
        {
            var solicitud = await _context.Solicitudes
                .Include(s => s.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (solicitud == null)
            {
                return NotFound();
            }

            if (solicitud.TutorId == null || solicitud.Tutor == null)
            {
                return BadRequest("La solicitud no tiene un tutor asignado.");
            }

            var document = new ActaDesignacionTutorDocument(solicitud);
            var pdfBytes = document.GeneratePdf();

            return File(pdfBytes, "application/pdf", $"Acta_Designacion_Tutor_{solicitud.NombreEstudiante}.pdf");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreEstudiante,Carrera,FechaSolicitud,NombreProyecto,Estado")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes
                .Include(s => s.MiembrosTribunal)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitud == null)
            {
                return NotFound();
            }

            var todosLosMiembros = await _context.MiembroTribunal.ToListAsync();
            var viewModel = new AsignacionTribunalViewModel
            {
                Solicitud = solicitud,
                MiembrosDisponibles = todosLosMiembros.Select(miembro => new MiembroTribunalAsignado
                {
                    Id = miembro.Id,
                    NombreCompleto = miembro.NombreCompleto,
                    Asignado = solicitud.MiembrosTribunal.Any(m => m.Id == miembro.Id)
                }).ToList()
            };

            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "NombreCompleto", solicitud.TutorId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AsignacionTribunalViewModel viewModel)
        {
            if (id != viewModel.Solicitud.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(viewModel.Solicitud.NombreEstudiante) || string.IsNullOrWhiteSpace(viewModel.Solicitud.Carrera))
            {
                ModelState.AddModelError("Solicitud.NombreEstudiante", "Los campos básicos de la solicitud son requeridos.");
            }

            if (!ModelState.IsValid)
            {
                ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "NombreCompleto", viewModel.Solicitud.TutorId);
                
                var todosLosMiembros = await _context.MiembroTribunal.ToListAsync();
                viewModel.MiembrosDisponibles = todosLosMiembros.Select(miembro => new MiembroTribunalAsignado
                {
                    Id = miembro.Id,
                    NombreCompleto = miembro.NombreCompleto,
                    Asignado = viewModel.MiembrosDisponibles?.Any(m => m.Id == miembro.Id && m.Asignado) ?? false
                }).ToList();

                return View(viewModel);
            }

            var solicitudToUpdate = await _context.Solicitudes
                .Include(s => s.MiembrosTribunal)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitudToUpdate == null)
            {
                return NotFound();
            }

            solicitudToUpdate.NombreEstudiante = viewModel.Solicitud.NombreEstudiante;
            solicitudToUpdate.Carrera = viewModel.Solicitud.Carrera;
            solicitudToUpdate.FechaSolicitud = viewModel.Solicitud.FechaSolicitud;
            solicitudToUpdate.NombreProyecto = viewModel.Solicitud.NombreProyecto;
            solicitudToUpdate.Estado = viewModel.Solicitud.Estado;
            solicitudToUpdate.TutorId = viewModel.Solicitud.TutorId;
            solicitudToUpdate.CalificacionFinal = viewModel.Solicitud.CalificacionFinal;

            solicitudToUpdate.MiembrosTribunal.Clear();
            if (viewModel.MiembrosDisponibles != null)
            {
                foreach (var miembroViewModel in viewModel.MiembrosDisponibles.Where(m => m.Asignado))
                {
                    var miembroDb = await _context.MiembroTribunal.FindAsync(miembroViewModel.Id);
                    if (miembroDb != null)
                    {
                        solicitudToUpdate.MiembrosTribunal.Add(miembroDb);
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(viewModel.Solicitud.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes
                .Include(s => s.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud != null)
            {
                _context.Solicitudes.Remove(solicitud);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitudes.Any(e => e.Id == id);
        }
    }
}

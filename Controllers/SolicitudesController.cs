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

        // GET: Solicitudes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Solicitudes.Include(s => s.Tutor);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Panel(string searchString, int? tutorId, string estado)
        {
            var solicitudes = from s in _context.Solicitudes
                              .Include(s => s.Tutor)
                              .Include(s => s.MiembrosTribunal)
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                solicitudes = solicitudes.Where(s => s.NombreEstudiante.Contains(searchString));
            }

            if (tutorId.HasValue)
            {
                solicitudes = solicitudes.Where(s => s.TutorId == tutorId.Value);
            }

            if (!String.IsNullOrEmpty(estado))
            {
                solicitudes = solicitudes.Where(s => s.Estado == estado);
            }

            ViewData["TutorIdFilter"] = new SelectList(_context.Tutor, "Id", "NombreCompleto", tutorId);
            
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
            ViewData["EstadoFilter"] = new SelectList(estadosList, "Value", "Text", estado);


            return View(await solicitudes.ToListAsync());
        }

        // GET: Solicitudes/Details/5
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

        // GET: Solicitudes/GenerarActaPDF/5
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

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitudes/Create
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

        // GET: Solicitudes/Edit/5
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

        // POST: Solicitudes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AsignacionTribunalViewModel viewModel)
        {
            if (id != viewModel.Solicitud.Id)
            {
                return NotFound();
            }

            // Custom validation to ensure at least the basic fields of the request are valid.
            if (string.IsNullOrWhiteSpace(viewModel.Solicitud.NombreEstudiante) || string.IsNullOrWhiteSpace(viewModel.Solicitud.Carrera))
            {
                ModelState.AddModelError("Solicitud.NombreEstudiante", "Los campos básicos de la solicitud son requeridos.");
            }

            if (!ModelState.IsValid)
            {
                // Repopulate necessary data for the view if validation fails
                ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "NombreCompleto", viewModel.Solicitud.TutorId);
                
                // Repopulate MiembrosDisponibles for the view
                var todosLosMiembros = await _context.MiembroTribunal.ToListAsync();
                viewModel.MiembrosDisponibles = todosLosMiembros.Select(miembro => new MiembroTribunalAsignado
                {
                    Id = miembro.Id,
                    NombreCompleto = miembro.NombreCompleto,
                    Asignado = viewModel.MiembrosDisponibles?.Any(m => m.Id == miembro.Id && m.Asignado) ?? false
                }).ToList();

                return View(viewModel);
            }

            // Re-fetch the entity to update it (since we used AsNoTracking earlier)
            var solicitudToUpdate = await _context.Solicitudes
                .Include(s => s.MiembrosTribunal)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitudToUpdate == null)
            {
                return NotFound();
            }

            // Update basic properties of the request
            solicitudToUpdate.NombreEstudiante = viewModel.Solicitud.NombreEstudiante;
            solicitudToUpdate.Carrera = viewModel.Solicitud.Carrera;
            solicitudToUpdate.FechaSolicitud = viewModel.Solicitud.FechaSolicitud;
            solicitudToUpdate.NombreProyecto = viewModel.Solicitud.NombreProyecto;
            solicitudToUpdate.Estado = viewModel.Solicitud.Estado;
            solicitudToUpdate.TutorId = viewModel.Solicitud.TutorId;
            solicitudToUpdate.CalificacionFinal = viewModel.Solicitud.CalificacionFinal;

            // Update tribunal
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


        // GET: Solicitudes/Delete/5
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

        // POST: Solicitudes/Delete/5
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

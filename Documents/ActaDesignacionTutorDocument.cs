
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using SistemaTitulos.Models;
using System;

namespace SistemaTitulos.Documents
{
    public class ActaDesignacionTutorDocument : IDocument
    {
        private readonly Solicitud _solicitud;

        public ActaDesignacionTutorDocument(Solicitud solicitud)
        {
            _solicitud = solicitud;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("I.T. ESCUELA INDUSTRIAL SUPERIOR “Pedro Domingo Murillo”")
                        .SemiBold().FontSize(16).AlignCenter();

                    column.Item().Text("CARRERA DE INFORMÁTICA INDUSTRIAL")
                        .SemiBold().FontSize(14).AlignCenter();
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(25);

                column.Item().AlignCenter().Text("ACTA DE DESIGNACIÓN DE TUTOR")
                    .Bold().FontSize(20).Underline();
                
                column.Item().PaddingTop(20).Text(text =>
                {
                    text.Span("En la ciudad de La Paz, a los ").SemiBold();
                    text.Span($"{DateTime.Now:dd 'días del mes de' MMMM 'de' yyyy}").Underline();
                    text.Span(", se procede a la designación oficial del tutor para el trabajo de titulación del/de la estudiante:").NormalWeight();
                });

                column.Item().AlignCenter().Text(_solicitud.NombreEstudiante)
                    .Bold().FontSize(16);

                column.Item().Text(text =>
                {
                    text.Span("Carrera: ").SemiBold();
                    text.Span(_solicitud.Carrera);
                });

                column.Item().Text(text =>
                {
                    text.Span("Nombre del Proyecto: ").SemiBold();
                    text.Span(_solicitud.NombreProyecto);
                });

                column.Item().Text(text =>
                {
                    text.Span("Tutor Designado: ").SemiBold();
                    text.Span(_solicitud.Tutor?.NombreCompleto ?? "Tutor no especificado")
                        .Bold();
                });

                column.Item().PaddingTop(50).Text("Para constancia de la presente designación, firman al pie del documento las partes interesadas.")
                    .Italic();

                column.Item().PaddingTop(80).Row(row =>
                {
                    row.RelativeItem().Column(col => 
                    {
                        col.Item().AlignCenter().Text("_________________________");
                        col.Item().AlignCenter().Text(_solicitud.NombreEstudiante).Bold();
                        col.Item().AlignCenter().Text("Estudiante");
                    });

                    row.RelativeItem().Column(col => 
                    {
                        col.Item().AlignCenter().Text("_________________________");
                        col.Item().AlignCenter().Text(_solicitud.Tutor?.NombreCompleto ?? " ").Bold();
                        col.Item().AlignCenter().Text("Tutor");
                    });
                });

                column.Item().PaddingTop(50).Row(row =>
                {
                    row.ConstantItem(100);
                    row.RelativeItem().Column(col => 
                    {
                        col.Item().AlignCenter().Text("_________________________");
                        col.Item().AlignCenter().Text("Director de Carrera").Bold();
                    });
                    row.ConstantItem(100);
                });
            });
        }
    }
}

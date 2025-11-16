
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using SistemaTitulos.Models;
using System.Linq;

namespace SistemaTitulos.Documents
{
    public class ActaDefensaDocument : IDocument
    {
        private readonly Solicitud _solicitud;

        public ActaDefensaDocument(Solicitud solicitud)
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
                        .SemiBold().FontSize(16);

                    column.Item().Text("CARRERA DE INFORMÁTICA INDUSTRIAL")
                        .SemiBold().FontSize(14);
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);

                column.Item().AlignCenter().Text("ACTA DE DEFENSA DE TRABAJO DE TITULACIÓN")
                    .SemiBold().FontSize(20).Underline();
                
                column.Item().Text(text =>
                {
                    text.Span("Siendo las ").SemiBold();
                    text.Span($"{_solicitud.FechaSolicitud:HH:mm} ").Underline();
                    text.Span("del día ").SemiBold();
                    text.Span($"{_solicitud.FechaSolicitud:dd 'de' MMMM 'de' yyyy}").Underline();
                    text.Span(", se instala el Tribunal Calificador para receptar la defensa del trabajo de titulación del estudiante:").SemiBold();
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
                    text.Span("Tutor: ").SemiBold();
                    text.Span(_solicitud.Tutor?.NombreCompleto ?? "No asignado");
                });

                column.Item().Text("Tribunal Calificador:").SemiBold();
                
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(2);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Nombre");
                        header.Cell().Text("Firma");
                    });

                    foreach (var miembro in _solicitud.MiembrosTribunal)
                    {
                        table.Cell().Text(miembro.NombreCompleto);
                        table.Cell().BorderBottom(1).Text(" ");
                    }
                });

                column.Item().Text("Observaciones:").SemiBold();
                column.Item().Border(1).Padding(10).Height(100).Text(" ");

                column.Item().Text("Calificación Final: _______ / 100").SemiBold().AlignCenter();
            });
        }
    }
}

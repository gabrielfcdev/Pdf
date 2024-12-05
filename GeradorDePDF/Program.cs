using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

class Program
{
    static void Main(string[] args)
    {
        QuestPDF.Settings.License = LicenseType.Community; // Configura a licença de uso gratuito
        
        Console.WriteLine("Gerando PDF personalizado...");

        var caminhoArquivo = "DocumentoPersonalizado.pdf";

        // Criação do PDF
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                page.Header().Text("Título do Documento").FontSize(20).Bold().AlignCenter();

                page.Content().Column(column =>
                {
                    column.Item().Text("Olá, este é um PDF personalizado!");
                    column.Item().Text("Gerado com C# e QuestPDF.");
                    // Se quiser adicionar imagem, substitua o caminho
                    // column.Item().Image("caminho-da-imagem.png");
                });

                page.Footer().AlignRight().Text($"Gerado em {DateTime.Now:dd/MM/yyyy}");
            });
        }).GeneratePdf(caminhoArquivo);

        Console.WriteLine($"PDF gerado com sucesso: {caminhoArquivo}");
    }
}

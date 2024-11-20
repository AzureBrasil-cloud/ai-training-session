using Azure.AI.DocumentIntelligence;
using Azure;
using Microsoft.Playwright;

namespace CrmPdfParser;

internal class Program
{
    static async Task Main(string[] args)
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // In Real world , this should be true to now show the browser
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://localhost:5268");

        // Start the task of waiting for the download before clicking
        var waitForDownloadTask = page.WaitForDownloadAsync();
        await page.GetByText("Clique aqui para baixar a lista.").ClickAsync();
        var download = await waitForDownloadTask;
        var fileStream = await download.CreateReadStreamAsync();

        var endpoint = Environment.GetEnvironmentVariable("AZURE_DI_ENDPOINT");
        var key = Environment.GetEnvironmentVariable("AZURE_DI_KEY");
        var credential = new AzureKeyCredential(key);
        var client = new DocumentIntelligenceClient(new Uri(endpoint), credential);

        var content = new AnalyzeDocumentContent
        {
            Base64Source = await BinaryData.FromStreamAsync(fileStream)
        };
        var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content);
        var result = operation.Value;

        var suspensionList = new List<Medico>();
        for (int i = 0; i < result.Tables.Count; i++)
        {
            var table = result.Tables[i];

            Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

            var tableRows = table.Cells.GroupBy(x => x.RowIndex).ToList();
            for (int j = 1; j < tableRows.Count; j++)
            {
                var row = tableRows[j].ToList();
                suspensionList.Add(new Medico
                {
                    Nome = row[0].Content,
                    CRM = row[1].Content,
                    MotivoSuspensao = row[2].Content
                });
            }
        }

        foreach (var medico in suspensionList)
        {
            Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}, Motivo de Suspensão: {medico.MotivoSuspensao}");
        }
    }
}

public class Medico
{
    public string Nome { get; set; }
    public string CRM { get; set; }
    public string MotivoSuspensao { get; set; }
}
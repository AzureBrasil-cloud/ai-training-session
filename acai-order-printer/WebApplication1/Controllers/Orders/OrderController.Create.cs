using Azure.AI.DocumentIntelligence;
using Microsoft.AspNetCore.Mvc;
using Azure;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using ESCPOS_NET.Utilities;

namespace WebApplication1.Controllers.Orders;

public partial class OrderController
{
    [HttpGet("/order/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        IFormFile? imageFile,
        [FromServices] IConfiguration configuration,
        [FromServices] ILogger<OrderController> logger)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            ModelState.AddModelError("", "Please select an image file to upload.");
            return View();
        }

        // Validate if the uploaded file is an image
        var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
        var fileExt = Path.GetExtension(imageFile.FileName).Substring(1).ToLower();

        if (!supportedTypes.Contains(fileExt))
        {
            ModelState.AddModelError("", "Invalid file type. Only JPG, JPEG, PNG, and GIF are allowed.");
            return View();
        }

        // Use Azure Document Intelligence to extract text from the image
        var client = new DocumentIntelligenceClient(new Uri(configuration["AZURE_DI_ENDPOINT"]), new AzureKeyCredential(configuration["AZURE_DI_KEY"]));
        //var content = new BinaryData(imageFile.OpenReadStream());
        var content = new AnalyzeDocumentContent
        {
            Base64Source = await BinaryData.FromStreamAsync(imageFile.OpenReadStream())
        };
        
        var operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content,
            features: [DocumentAnalysisFeature.KeyValuePairs]);

        // TODO: Desafio: Montar o pedido com base nas informações extraídas da imagem
        // Take the Key-Value pairs extracted from the image and convert to a string with line breaks
        var orderStr = operation.Value.KeyValuePairs
            .Where(kvp => kvp.Key != null)
            .Select(kvp => $"{kvp.Key.Content}: {kvp.Value?.Content ?? string.Empty}")
            .ToList();

        // Print the receipt
        await PrintReceipt(orderStr, logger);

        ViewBag.Message = $"Pedido feito com sucesso! <br/> {string.Join("<br/>", orderStr)}";
        return View();
    }

    private async Task PrintReceipt(List<string> receiptLines, ILogger<OrderController> logger)
    {
        try
        {
            var printer = new SerialPrinter("COM2", 115200);

            var e = new EPSON();
            var receipt = ByteSplicer.Combine(
                e.CodePage(CodePage.PC860_PORTUGUESE),
                e.CenterAlign(),
                e.PrintLine("AzureBrasil.Cloud"),
                e.PrintLine("Pedido de Açai"),
                e.PrintLine(""),
                e.LeftAlign()
            );

            foreach (var line in receiptLines)
            {
                receipt = ByteSplicer.Combine(receipt, e.PrintLine(line));
            }

            receipt = ByteSplicer.Combine(receipt,
                e.PrintLine(""),
                e.CenterAlign(),
                e.PrintLine("Obrigado pela preferência!"),
                e.FullCutAfterFeed(5));

            printer.Write(receipt);
            await Task.Delay(TimeSpan.FromSeconds(5));
            printer.Dispose();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to print receipt");
        }
    }
}
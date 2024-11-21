using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

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
        [FromServices] DocumentIntelligenceService documentService,
        [FromServices] ILogger<OrderController> logger)
    {
        if (!ValidateImage(imageFile))
        {
            return View();
        }

        // Use Azure Document Intelligence to extract text from the image
        var analyzeResult = await documentService.AnalyzeDocument(imageFile.OpenReadStream());

        // TODO: Desafio: Montar o pedido com base nas informações extraídas da imagem
        // Take the Key-Value pairs extracted from the image and convert to a string with line breaks
        var orderStr = analyzeResult.KeyValuePairs
            .Where(kvp => kvp.Key != null)
            .Select(kvp => $"{kvp.Key.Content}: {kvp.Value?.Content ?? string.Empty}")
            .ToList();

        // Print the receipt
        await PrintReceipt(orderStr, logger);

        ViewBag.Message = $"Pedido feito com sucesso! <br/> {string.Join("<br/>", orderStr)}";
        return View();
    }
}
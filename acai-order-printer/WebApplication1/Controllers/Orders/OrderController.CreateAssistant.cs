using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers.Orders;

public partial class OrderController
{
    [HttpGet("/order/create/ai")]
    public IActionResult CreateAi()
    {
        return View("CreateAi");
    }

    [HttpPost("/order/create/ai")]
    [Experimental("OPENAI001")]
    public async Task<IActionResult> CreateAi(
        IFormFile? imageFile,
        [FromServices] DocumentIntelligenceService documentService,
        [FromServices] AzureOpenAiService aiService,
        [FromServices] ILogger<OrderController> logger)
    {
        if (!ValidateImage(imageFile))
        {
            return View("CreateAi");
        }

        // Use Azure Document Intelligence to extract text from the image
        var analyzeResult = await documentService.AnalyzeDocument(imageFile.OpenReadStream());
        // Use AI to build or order object
        var order = await aiService.AnalyzeAcaiOrder(analyzeResult.Content);

        // Print the receipt
        await PrintReceipt([order], logger);

        ViewBag.Message = $"Pedido feito com sucesso! <br/> {string.Join("<br/>", order)}";
        return View("CreateAi");
    }
}
﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
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
        var assistantOrder = await aiService.AnalyzeAcaiOrder(analyzeResult.Content);
        logger.LogInformation("Assistant Order: {AssistantOrder}", assistantOrder);
        var order = JsonSerializer.Deserialize<AcaiOrder>(assistantOrder, JsonSerializerOptions.Web);

        // Print the receipt
        var orderReceipt = order.ToReceipt();
        await PrintReceipt(orderReceipt, logger);

        ViewBag.Message = $"Pedido feito com sucesso! <br/> {string.Join("<br/>", orderReceipt)}";
        return View("CreateAi");
    }
}
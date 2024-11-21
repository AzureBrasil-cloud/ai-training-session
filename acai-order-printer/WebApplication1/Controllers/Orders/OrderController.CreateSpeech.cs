using System.Diagnostics.CodeAnalysis;
using Azure.AI.DocumentIntelligence;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers.Orders;

public partial class OrderController
{
    [HttpGet("/order/create/speech")]
    public IActionResult CreateSpeech()
    {
        return View("CreateSpeech");
    }

    [HttpPost("/order/create/speech")]
    [Experimental("OPENAI001")]
    public async Task<IActionResult> CreateSpeech(
        IFormFile? audioFile,
        [FromServices] AzureSpeechService speechService,
        [FromServices] AzureOpenAiService aiService,
        [FromServices] ILogger<OrderController> logger)
    {
        if (!ValidateAudioFile(audioFile))
        {
            return View("CreateSpeech");
        }

        var orderSpeech = await speechService.TranscribeAudioAsync(audioFile.OpenReadStream(), audioFile.FileName);
        // Use AI to build or order object
        var assistantOrder = await aiService.AnalyzeAcaiOrder(orderSpeech.CombinedPhrases.FirstOrDefault()?.Text);
        logger.LogInformation("Assistant Order: {AssistantOrder}", assistantOrder);
        var order = JsonSerializer.Deserialize<AcaiOrder>(assistantOrder, JsonSerializerOptions.Web);

        // Print the receipt
        var orderReceipt = order.ToReceipt();
        await PrintReceipt(orderReceipt, logger);

        ViewBag.Message = $"Pedido feito com sucesso! <br/> {string.Join("<br/>", orderReceipt)}";
        return View("CreateSpeech");
    }
}
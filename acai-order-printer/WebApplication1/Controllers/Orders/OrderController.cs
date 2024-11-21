using ESCPOS_NET.Emitters;
using ESCPOS_NET.Utilities;
using ESCPOS_NET;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Orders;

public partial class OrderController : Controller
{
    private bool ValidateImage(IFormFile? imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            ModelState.AddModelError("", "Please select an image file to upload.");
            return false;
        }
        var supportedTypes = new[] { "jpg", "jpeg", "png", "gif" };
        var fileExt = Path.GetExtension(imageFile.FileName).Substring(1).ToLower();
        if (!supportedTypes.Contains(fileExt))
        {
            ModelState.AddModelError("", "Invalid file type. Only JPG, JPEG, PNG, and GIF are allowed.");
            return false;
        }
        
        return true;
    }
    private bool ValidateAudioFile(IFormFile? audioFile)
    {
        if (audioFile == null || audioFile.Length == 0)
        {
            ModelState.AddModelError("", "Please select an audio file to upload.");
            return false;
        }

        // List of supported audio file extensions
        var supportedTypes = new[] { "wav", "mp3", "m4a", "ogg", "aac", "flac" };
        var fileExt = Path.GetExtension(audioFile.FileName).Substring(1).ToLower();

        if (!supportedTypes.Contains(fileExt))
        {
            ModelState.AddModelError("", "Invalid file type. Only WAV, MP3, M4A, OGG, AAC, and FLAC are allowed.");
            return false;
        }

        return true;
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
using System.Text.Json;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class AzureSpeechService(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger<AzureSpeechService> logger)
{
    public async Task<SpeechTranscriptionResult> TranscribeAudioAsync(Stream audioStream, string fileName)
    {
        try
        {
            var httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(configuration["AzureSpeech:TranscriptionUrl"]);
            // Add headers
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", configuration["AzureSpeech:Key"]);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            using var formData = new MultipartFormDataContent();
            formData.Headers.ContentType.MediaType = "multipart/form-data";

            // Add audio file to form-data
            formData.Add(new StreamContent(audioStream), "audio", fileName);

            // Add definition JSON to form-data
            var definition = new
            {
                locales = new[] { "pt-BR" },
                profanityFilterMode = "Masked",
                channels = new[] { 0 }
            };

            var definitionContent = new StringContent(JsonSerializer.Serialize(definition), Encoding.UTF8);
            formData.Add(definitionContent, "definition");

            // Make the HTTP POST request
            var response = await httpClient.PostAsync("/speechtotext/transcriptions:transcribe?api-version=2024-05-15-preview", formData);

            // Ensure the response is successful
            response.EnsureSuccessStatusCode();

            // Read and return the response content
            var result = await response.Content.ReadFromJsonAsync<SpeechTranscriptionResult>();
            return result;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error transcribing audio.");
            return new SpeechTranscriptionResult();
        }
    }
}
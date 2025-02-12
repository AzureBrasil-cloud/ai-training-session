using Azure;
using Azure.AI.DocumentIntelligence;

namespace WebApplication1.Services;

public class DocumentIntelligenceService(IConfiguration configuration)
{
    private readonly DocumentIntelligenceClient _client = new(new Uri(configuration["AzureDocumentIntelligence:Endpoint"]), 
        new AzureKeyCredential(configuration["AzureDocumentIntelligence:Key"]));

    public async Task<AnalyzeResult> AnalyzeDocument(Stream document)
    {
        var binaryData = await BinaryData.FromStreamAsync(document);

        var operation = await _client.AnalyzeDocumentAsync(WaitUntil.Completed, 
            new AnalyzeDocumentOptions("prebuilt-layout", binaryData)
            {
                Features = { new DocumentAnalysisFeature("keyValuePairs") },
            });

        return operation.Value;
    }
}
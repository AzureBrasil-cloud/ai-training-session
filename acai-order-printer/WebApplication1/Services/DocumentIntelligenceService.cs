using Azure;
using Azure.AI.DocumentIntelligence;

namespace WebApplication1.Services;

public class DocumentIntelligenceService(IConfiguration configuration)
{
    private readonly DocumentIntelligenceClient _client = new(new Uri(configuration["AzureDocumentIntelligence:Endpoint"]), new AzureKeyCredential(configuration["AzureDocumentIntelligence:Key"]));

    public async Task<AnalyzeResult> AnalyzeDocument(Stream document)
    {
        var content = new AnalyzeDocumentContent
        {
            Base64Source = await BinaryData.FromStreamAsync(document)
        };

        var operation = await _client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content,
            features: [DocumentAnalysisFeature.KeyValuePairs]);
        
        return operation.Value;
    }
}
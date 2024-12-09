using FoodReviewApp.Models;
using FoodReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodReviewApp;

public static class Endpoints
{
    public static WebApplication UseAppEndpoints(this WebApplication app)
    {
        app.MapPost("/binary-classification",
                async ([FromServices] FoodReviewService service, [FromBody] ReviewRequest request) =>
                {
                    var result = await service.BinaryClassificationAsync(request);
                    return Results.Ok(result);
                })
            .WithName("BinaryClassification")
            .WithOpenApi();
        
        app.MapPost("/multi-classification",
                async ([FromServices] FoodReviewService service, [FromBody] ReviewRequest request) =>
                {
                    var result = await service.MultiClassificationAsync(request);
                    return Results.Ok(result);
                })
            .WithName("MultiClassification")
            .WithOpenApi();

        return app;
    }
}
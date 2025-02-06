using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpLogging();
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<AzureOpenAIClient>(new AzureOpenAIClient(
                new Uri(builder.Configuration["AzureOpenAi:Endpoint"]),
                new AzureKeyCredential(builder.Configuration["AzureOpenAi:Key"])));

            builder.Services.AddSingleton<ChatClient>(sp =>
            {
                var azureAiClient = sp.GetRequiredService<AzureOpenAIClient>();
                return azureAiClient.GetChatClient(builder.Configuration["AzureOpenAi:Model"]);
            });

            builder.Services.AddTransient<DocumentIntelligenceService>();
            builder.Services.AddTransient<AzureOpenAiService>();
            builder.Services.AddTransient<AzureSpeechService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpLogging();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

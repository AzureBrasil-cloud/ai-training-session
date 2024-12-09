using BlogWriterAssistantApp;
using BlogWriterAssistantApp.Services.Assistants;
using BlogWriterAssistantApp.Services.ChatCompletions;
using BlogWriterAssistantApp.Services.Threads;
using BlogWriterAssistantApp.Services.ToolHandler;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAssistantService, AssistantService>();
builder.Services.AddScoped<IThreadService, ThreadService>();
builder.Services.AddScoped<IChatCompletionsService, ChatCompletionsService>();
builder.Services.AddScoped<IToolHandler, ToolHandler>();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseAppEndpoints();
app.Run();
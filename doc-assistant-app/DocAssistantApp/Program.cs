using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

var model = config["AzureOpenAi:Model"]!;
var key = config["AzureOpenAi:Key"]!;
var endpoint = config["AzureOpenAi:Endpoint"]!;

var a = 1;
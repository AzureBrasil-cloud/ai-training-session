# ai-training-session
Repo with samples for our training session day

### Playwright
https://playwright.dev/dotnet/docs/library

# Install required browsers - replace netX with actual output folder name, e.g. net8.0.
dotnet build
pwsh .\CrmPdfParser\bin\Debug\net9.0\playwright.ps1 install

# If the pwsh command does not work (throws TypeNotFound), make sure to use an up-to-date version of PowerShell.
dotnet tool update --global PowerShell

# Before running the console app create a file called launchsettings.json in the CrmPdfParser project  under Properties folder with the following content:
{
  "profiles": {
    "CrmPdfParser": {
      "commandName": "Project",
      "environmentVariables": {
        "AZURE_DI_KEY": "<sua-chave>",
        "AZURE_DI_ENDPOINT": "<seu-endpoint>"
      }
    }
  }
}
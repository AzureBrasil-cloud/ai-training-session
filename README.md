# ai-training-session
Repo with samples for our training session day

### Playwright
https://playwright.dev/dotnet/docs/library

# Install required browsers - replace netX with actual output folder name, e.g. net8.0.
pwsh bin/Debug/netX/playwright.ps1 install

# If the pwsh command does not work (throws TypeNotFound), make sure to use an up-to-date version of PowerShell.
dotnet tool update --global PowerShell
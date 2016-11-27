# Telegram bot prototype
This simple bot echos any user text message and saves images to local storage

## Configuration

- Set environment variable `ASPNETCORE_ENVIRONMENT=Development`
- type `dotnet restore`
- type `dotnet user-secrets set BotToken <token>` in order to setup bot token
- add webhook domain to `appsettings.json`
- type `dotnet run`

## Development
For develop and test telegram bot using webhooks on local machine. You may use `tools/expose.ps1` file that using `ngrok`

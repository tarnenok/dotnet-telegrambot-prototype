using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBot.WebApi.Models;

namespace TelegramBot.WebApi.Extensions
{
    public static class TelegramExtenstions
    {
        public static void AddTelegramBot(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var settings = new AppSettings();
            configuration.Bind(settings);
            services.AddSingleton(settings);

            var client = new TelegramBotClient(settings.BotToken);
            services.AddSingleton<ITelegramBotClient>(client);
        }

        public static IApplicationBuilder UseTelegramBot(this IApplicationBuilder app, string webhookPath)
        {
            var settings = app.ApplicationServices.GetService<AppSettings>();
            var botClient = app.ApplicationServices.GetService<ITelegramBotClient>();

            botClient.SetWebhookAsync(settings.Domain.TrimEnd('/') + webhookPath)
                .GetAwaiter()
                .GetResult();
            return app;
        }
    }
}
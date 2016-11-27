using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.WebApi.Controllers
{
    [Route("/webhook")]
    public class WebHookController : Controller
    {
        private readonly ITelegramBotClient _botClient;

        public WebHookController(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> GetMessage([FromBody]Update update)
        {
            var message = update.Message;

            if (message.Type == MessageType.TextMessage)
            {
                await _botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
            else if (message.Type == MessageType.PhotoMessage)
            {
                var file = await _botClient.GetFileAsync(message.Photo.LastOrDefault()?.FileId);

                var filename = file.FileId + "." + file.FilePath.Split('.').Last();

                using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                {
                    await file.FileStream.CopyToAsync(saveImageStream);
                }

                await _botClient.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
            }

            return Ok();
        }
    }
}

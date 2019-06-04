using Telegram.Bot;

namespace TelegramBotApp.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}

using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBotApp.Services
{
    public interface IUpdateService
    {
        Task Update(Update update);
    }
}

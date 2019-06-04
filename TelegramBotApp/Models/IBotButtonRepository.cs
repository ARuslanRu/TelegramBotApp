using System.Linq;

namespace TelegramBotApp.Models
{
    public interface IBotButtonRepository
    {
        IQueryable<BotButton> BotButtons { get; }
    }
}

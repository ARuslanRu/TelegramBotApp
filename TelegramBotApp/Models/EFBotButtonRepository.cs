using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBotApp.Models
{
    public class EFBotButtonRepository : IBotButtonRepository
    {
        private TelegramBotAppDbContext context;
        public EFBotButtonRepository(TelegramBotAppDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<BotButton> BotButtons => context.BotButtons;
    }
}

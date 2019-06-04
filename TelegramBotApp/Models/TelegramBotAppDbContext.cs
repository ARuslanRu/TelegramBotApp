using Microsoft.EntityFrameworkCore;

namespace TelegramBotApp.Models
{
    public class TelegramBotAppDbContext : DbContext
    {
        public TelegramBotAppDbContext(DbContextOptions<TelegramBotAppDbContext> options)
           : base(options) { }

        public DbSet<BotButton> BotButtons { get; set; }
    }
}

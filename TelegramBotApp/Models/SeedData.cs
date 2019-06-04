using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TelegramBotApp.Models
{
    public class SeedData
    {
        public static void EnshurePopulated(IApplicationBuilder app)
        {
            TelegramBotAppDbContext context = app.ApplicationServices.GetRequiredService<TelegramBotAppDbContext>();
            context.Database.Migrate();
            if (!context.BotButtons.Any())
            {
                #region Данный вариант хаотично заполняет тбалицу дефолтными значениями
                //context.BotButtons.AddRange(
                //new BotButton { ParentId = 0, Row = 1, Column = 1, ButtonName = "Игры" },
                //new BotButton { ParentId = 0, Row = 2, Column = 1, ButtonName = "Рецепты" },
                //new BotButton { ParentId = 0, Row = 3, Column = 1, ButtonName = "Литература" },

                //new BotButton { ParentId = 1, Row = 1, Column = 1, ButtonName = "Аркады" },
                //new BotButton { ParentId = 1, Row = 1, Column = 2, ButtonName = "Стратегии" },
                //new BotButton { ParentId = 1, Row = 2, Column = 1, ButtonName = "Симуляторы" },
                //new BotButton { ParentId = 1, Row = 2, Column = 2, ButtonName = "РПГ" },
                //new BotButton { ParentId = 1, Row = 2, Column = 3, ButtonName = "Экшн" },

                //new BotButton { ParentId = 2, Row = 3, Column = 1, ButtonName = "Рецепт 1" },
                //new BotButton { ParentId = 2, Row = 3, Column = 2, ButtonName = "Рецепт 2" },

                //new BotButton { ParentId = 3, Row = 1, Column = 1, ButtonName = "Первый подраздел" },
                //new BotButton { ParentId = 3, Row = 1, Column = 2, ButtonName = "Второй подраздел" },
                //new BotButton { ParentId = 3, Row = 2, Column = 1, ButtonName = "Третий подраздел" },

                //new BotButton { ParentId = 10, Row = 1, Column = 1, ButtonName = "Первый подраздел" },
                //new BotButton { ParentId = 10, Row = 1, Column = 2, ButtonName = "Второй подраздел" },
                //new BotButton { ParentId = 10, Row = 2, Column = 1, ButtonName = "Третий подраздел" },

                //new BotButton { ParentId = 16, Row = 1, Column = 1, ButtonName = "Фантастика" },
                //new BotButton { ParentId = 16, Row = 2, Column = 1, ButtonName = "Комедия" },
                //new BotButton { ParentId = 16, Row = 3, Column = 1, ButtonName = "Ужасы" },
                //new BotButton { ParentId = 16, Row = 4, Column = 1, ButtonName = "Фентези" });
                //context.SaveChanges();
                #endregion

                #region Данный вариант заполняет таблицу в том порядке в котором она описана тут

                var list = new List<BotButton>();

                list.Add(new BotButton { ParentId = 0, Row = 1, Column = 1, ButtonName = "Игры" });
                list.Add(new BotButton { ParentId = 0, Row = 2, Column = 1, ButtonName = "Рецепты" });
                list.Add(new BotButton { ParentId = 0, Row = 3, Column = 1, ButtonName = "Литература" });

                list.Add(new BotButton { ParentId = 1, Row = 1, Column = 1, ButtonName = "Аркады" });
                list.Add(new BotButton { ParentId = 1, Row = 1, Column = 2, ButtonName = "Стратегии" });
                list.Add(new BotButton { ParentId = 1, Row = 2, Column = 1, ButtonName = "Симуляторы" });
                list.Add(new BotButton { ParentId = 1, Row = 2, Column = 2, ButtonName = "РПГ" });
                list.Add(new BotButton { ParentId = 1, Row = 2, Column = 3, ButtonName = "Экшн" });

                list.Add(new BotButton { ParentId = 2, Row = 3, Column = 1, ButtonName = "Рецепт 1" });
                list.Add(new BotButton { ParentId = 2, Row = 3, Column = 2, ButtonName = "Рецепт 2" });

                list.Add(new BotButton { ParentId = 4, Row = 1, Column = 1, ButtonName = "Аркада 1" });
                list.Add(new BotButton { ParentId = 4, Row = 1, Column = 2, ButtonName = "Аркада 2" });
                list.Add(new BotButton { ParentId = 4, Row = 2, Column = 1, ButtonName = "Аркада 3" });

                list.Add(new BotButton { ParentId = 5, Row = 1, Column = 1, ButtonName = "Стратегия 1" });
                list.Add(new BotButton { ParentId = 5, Row = 1, Column = 2, ButtonName = "Стратегия 2" });
                list.Add(new BotButton { ParentId = 5, Row = 2, Column = 1, ButtonName = "Стратегия 3" });

                list.Add(new BotButton { ParentId = 3, Row = 1, Column = 1, ButtonName = "Фантастика" });
                list.Add(new BotButton { ParentId = 3, Row = 2, Column = 1, ButtonName = "Комедия" });
                list.Add(new BotButton { ParentId = 3, Row = 3, Column = 1, ButtonName = "Ужасы" });
                list.Add(new BotButton { ParentId = 3, Row = 4, Column = 1, ButtonName = "Фентези" });

                foreach (var item in list)
                {
                    context.BotButtons.Add(item);
                    context.SaveChanges();
                }
                #endregion
            }
        }
    }
}

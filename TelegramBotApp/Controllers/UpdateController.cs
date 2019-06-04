using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotApp.Services;

namespace TelegramBotApp.Controllers
{
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [Route("bot/update")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _updateService.Update(update);
            return Ok();
        }
    }
}

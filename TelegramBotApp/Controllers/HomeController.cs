using Microsoft.AspNetCore.Mvc;

namespace TelegramBotApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
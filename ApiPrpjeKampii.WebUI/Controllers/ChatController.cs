using Microsoft.AspNetCore.Mvc;

namespace ApiPrpjeKampii.WebUI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult SendChatWithAI()
        {
            return View();
        }
    }
}

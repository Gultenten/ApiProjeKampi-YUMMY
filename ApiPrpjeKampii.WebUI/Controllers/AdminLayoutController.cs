using Microsoft.AspNetCore.Mvc;

namespace ApiPrpjeKampii.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

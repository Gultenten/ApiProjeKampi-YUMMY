using Microsoft.AspNetCore.Mvc;

namespace ApiPrpjeKampii.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

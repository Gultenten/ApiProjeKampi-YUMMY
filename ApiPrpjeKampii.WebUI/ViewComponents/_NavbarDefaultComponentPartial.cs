using Microsoft.AspNetCore.Mvc;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _FooterDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }

    }
}

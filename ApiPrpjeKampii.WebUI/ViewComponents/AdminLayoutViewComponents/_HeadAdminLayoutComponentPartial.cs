using Microsoft.AspNetCore.Mvc;

namespace ApiPrpjeKampii.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _HeadAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}


using ApiPrpjeKampii.WebUI.Dtos.CategotyDtos;
using ApiPrpjeKampii.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiPrpjeKampii.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

using ApiPrpjeKampii.WebUI.Dtos.ChefDtos;
using ApiPrpjeKampii.WebUI.Dtos.EventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _ChefDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ChefDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/Chefs/");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsondata);
                    return View(values);
                }

                return View();
            }

        }
    }
}
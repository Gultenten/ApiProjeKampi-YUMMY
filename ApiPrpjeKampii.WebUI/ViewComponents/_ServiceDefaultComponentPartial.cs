using ApiPrpjeKampii.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ServiceDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/Services/");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata=await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsondata);
                    return View(values);
                }

                return View();
            }
        }
    }
}

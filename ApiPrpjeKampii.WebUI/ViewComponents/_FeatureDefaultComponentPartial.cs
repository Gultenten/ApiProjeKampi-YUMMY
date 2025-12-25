using ApiPrpjeKampii.WebUI.Dtos.FeatureDtos;
using ApiPrpjeKampii.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public _FeatureDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/Features/");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsondata);
                    return View(values);
                }

                return View();
            }

        }
    }
}


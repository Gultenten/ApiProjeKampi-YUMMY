using ApiPrpjeKampii.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _DefaultContactComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/Contacts/");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsondata);
                    return View(values);
                }

                return View();
            }
        }

    }
}

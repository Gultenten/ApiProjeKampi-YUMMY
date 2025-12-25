using ApiPrpjeKampii.WebUI.Dtos.ChefDtos;
using ApiPrpjeKampii.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/Messages/MessageListIsReadyFalse");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultMessageByIsReadFalseDto>>(jsondata);
                    return View(values);
                }

                return View();
            }
        }
    }
}
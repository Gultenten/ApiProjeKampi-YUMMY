using ApiPrpjeKampii.WebUI.Dtos.GroupReservationDtos;
using ApiPrpjeKampii.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents.DashboardMenuViewComponents
{
    public class _DashboardGroupReservationComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardGroupReservationComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/GroupReservations/");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultGroupReservationDto>>(jsondata);
                    return View(values);
                }

                return View();
            }
        }
    }
}

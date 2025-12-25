using ApiPrpjeKampii.WebUI.Dtos.ReservationDtos;
using ApiPrpjeKampii.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPrpjeKampii.WebUI.ViewComponents.DashboardMenuViewComponents
{
    public class _DashboardMainChartComponentPartial:ViewComponent
    {
       
          private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardMainChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7129/");

            var response = await client.GetAsync("api/Reservations/GetReservationStats");
            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<ReservationChartDto>>(json);

            return View(data);
        }
    }
    }


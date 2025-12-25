using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApiPrpjeKampii.WebUI.ViewComponents.HomePageViewComponents
{
    public class _HomePageStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7129/api/Statistics/ProductCount");
            var jsondata1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = jsondata1;


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7129/api/Statistics/ReservationCount");
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsondata2;



            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7129/api/Statistics/ChefCount");
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsondata3;


            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7129/api/Statistics/TotalGuestCount");
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsondata4;





            return View();
        }
    }

}

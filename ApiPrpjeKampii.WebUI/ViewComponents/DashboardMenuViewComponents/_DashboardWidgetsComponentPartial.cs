using ApiPrpjeKampii.WebUI.Dtos.CategotyDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiPrpjeKampii.WebUI.ViewComponents.DashboardMenuViewComponents
{
    public class _DashboardWidgetsComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardWidgetsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int r1, r2, r3, r4;
            Random rnd = new Random();
            r1 = rnd.Next(1, 35);
            r2 = rnd.Next(1, 35);
            r3 = rnd.Next(1, 35);
            r4 = rnd.Next(1, 35);



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7129/api/Reservations/GetTotalReservationCount");

            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v1 = jsondata;
            ViewBag.r1 = r1;
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);





            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7129/api/Reservations/GetTotalCustomerCount");

            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsondata2;
            ViewBag.r2 = r2;






            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7129/api/Reservations/GetPendingReservation");

            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsondata3;
            ViewBag.r3 = r3;








            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7129/api/Reservations/GetApprovedReservation");

            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsondata4;
            ViewBag.r4 = r4;




            return View();

        }
    }
}

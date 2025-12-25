using ApiPrpjeKampii.WebUI.Dtos.CategotyDtos;
using ApiPrpjeKampii.WebUI.Dtos.ServiceDtos;
using ApiPrpjeKampii.WebUI.Dtos.WhyChooseYummyDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiPrpjeKampii.WebUI.Controllers
{
    public class WhyChooseYummyController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory;
        public WhyChooseYummyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WhyChooseYummyList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7129/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyChooseYummyDto>>(jsondata);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateWhyChooseYummy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhyChooseYummy(CreateWhyChooseYummyDto createWhyChooseYummy)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWhyChooseYummy);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7129/api/Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyChooseYummyList");
            }

            return View();

        }
        public async Task<IActionResult> DeleteWhyChooseYummy(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7129/api/Services?id=" + id);
            return RedirectToAction("WhyChooseYummyList");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateWhyChooseYummy(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7129/api/Services/GetService?id=" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdWhyChooseYummyDto>(jsondata);
            return View(value);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateWhyChooseYummy(UpdateWhyChooseYummyDto updateWhyChooseYummy)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateWhyChooseYummy);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7129/api/Services/", stringContent);


            return RedirectToAction("WhyChooseYummyList");
        }
    }
}


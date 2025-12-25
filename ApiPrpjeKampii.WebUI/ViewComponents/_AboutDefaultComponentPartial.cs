using ApiPrpjeKampii.WebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiPrpjeKampii.WebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            {
                var client = _httpClientFactory.CreateClient();
                var ResponseMessage = await client.GetAsync("https://localhost:7129/api/Abouts/");
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
                    return View(values);
                }

                return View();
            }
        }



    }

    }
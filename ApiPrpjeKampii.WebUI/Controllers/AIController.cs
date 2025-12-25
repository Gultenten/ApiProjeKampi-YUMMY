

//namespace ApiPrpjeKampii.WebUI.Controllers
//    {
//        public class AIController : Controller
//        {
//            public IActionResult CreateRecipeWithOpenAI()
//            {
//                return View();
//            }

//            [HttpPost]
//            public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
//            {
//                var apiKey = ""; // Gemini API anahtarın
//                using var client = new HttpClient();

//                var requestdata = new
//                {
//                    contents = new[]
//                    {
//                    new
//                    {
//                        parts = new[]
//                        {
//                            new
//                            {
//                                text = $"Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Kullanıcının girdiği malzemelere göre yemek tarifi öner: {prompt}"
//                            }
//                        }
//                    }
//                }
//                };

//                var request = new HttpRequestMessage(HttpMethod.Post,
//                    $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={apiKey}");
//                request.Content = new StringContent(JsonSerializer.Serialize(requestdata), Encoding.UTF8, "application/json");

//                var response = await client.SendAsync(request);
//                var responseContent = await response.Content.ReadAsStringAsync();

//                if (response.IsSuccessStatusCode)
//                {
//                    using var doc = JsonDocument.Parse(responseContent);
//                    if (doc.RootElement.TryGetProperty("candidates", out var candidates) && candidates.GetArrayLength() > 0)
//                    {
//                        var content = candidates[0].GetProperty("content").GetProperty("parts")[0].GetProperty("text").GetString();
//                        ViewBag.recipe = content;
//                    }
//                    else
//                    {
//                        ViewBag.recipe = "Gemini API'den geçerli bir yanıt alınamadı.";
//                    }
//                }
//                else
//                {
//                    ViewBag.recipe = "Bir hata oluştu: " + response.StatusCode;
//                }

//                return View();
//            }

//        }
//    }

//using Microsoft.AspNetCore.Mvc;
//using System.Text;
//using System.Text.Json;

//namespace ApiPrpjeKampii.WebUI.Controllers
//{
//    public class AIController : Controller
//    {
//        public IActionResult CreateRecipeWithOpenAI()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
//        {
//            var apiKey = ""; // Gemini API anahtarın
//            using var client = new HttpClient();

//            var requestdata = new
//            {
//                contents = new[]
//                {
//                    new
//                    {
//                        parts = new[]
//                        {
//                            new
//                            {
//                                text = $"Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Kullanıcının girdiği malzemelere göre yemek tarifi öner: {prompt}"
//                            }
//                        }
//                    }
//                }
//            };



//            var request = new HttpRequestMessage(HttpMethod.Post,
//    $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={apiKey}");
//            request.Content = new StringContent(JsonSerializer.Serialize(requestdata), Encoding.UTF8, "application/json");

//            var response = await client.SendAsync(request);
//            var responseContent = await response.Content.ReadAsStringAsync();

//            // 👇 Geçici olarak JSON çıktısını doğrudan tarayıcıda gösteriyoruz
//            return Content(responseContent, "application/json");
//        }
//    }
//}


//using Microsoft.AspNetCore.Mvc;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace ApiPrpjeKampii.WebUI.Controllers
//{
//    public class AIController : Controller
//    {
//        public IActionResult CreateRecipeWithOpenAI()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
//        {
//            var apiKey = ""; // Gemini API anahtarın
//            using var client = new HttpClient();

//            var requestdata = new
//            {
//                contents = new[]
//                {
//                    new
//                    {
//                        parts = new[]
//                        {
//                            new
//                            {
//                                text = $"Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Kullanıcının girdiği malzemelere göre yemek tarifi öner: {prompt}"
//                            }
//                        }
//                    }
//                }
//            };

//            var request = new HttpRequestMessage(HttpMethod.Post,
//                $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={apiKey}");
//            request.Content = new StringContent(JsonSerializer.Serialize(requestdata), Encoding.UTF8, "application/json");

//            var response = await client.SendAsync(request);
//            var responseContent = await response.Content.ReadAsStringAsync();

//            try
//            {
//                using var doc = JsonDocument.Parse(responseContent);
//                var content = doc.RootElement
//                    .GetProperty("candidates")[0]
//                    .GetProperty("content")
//                    .GetProperty("parts")[0]
//                    .GetProperty("text")
//                    .GetString();

//                ViewBag.recipe = content;
//            }
//            catch
//            {
//                ViewBag.recipe = "Tarif oluşturulamadı. API yanıtı beklenen formatta değil.";
//            }

//            return View();
//        }
//    }
//}


//using Microsoft.AspNetCore.Mvc;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace ApiPrpjeKampii.WebUI.Controllers
//{
//    public class AIController : Controller
//    {
//        public IActionResult CreateRecipeWithOpenAI()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
//        {
//            var apiKey = ""; // Gemini API anahtarın
//            using var client = new HttpClient();

//            var requestdata = new
//            {
//                contents = new[]
//                {
//                    new
//                    {
//                        parts = new[]
//                        {
//                            new
//                            {
//                                text = $"Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Kullanıcının girdiği malzemelere göre yemek tarifi öner: {prompt}"
//                            }
//                        }
//                    }
//                }
//            };

//            var request = new HttpRequestMessage(HttpMethod.Post,
//                $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={apiKey}");
//            request.Content = new StringContent(JsonSerializer.Serialize(requestdata), Encoding.UTF8, "application/json");

//            var response = await client.SendAsync(request);
//            var responseContent = await response.Content.ReadAsStringAsync();

//            try
//            {
//                using var doc = JsonDocument.Parse(responseContent);
//                var content = doc.RootElement
//                    .GetProperty("candidates")[0]
//                    .GetProperty("content")
//                    .GetProperty("parts")[0]
//                    .GetProperty("text")
//                    .GetString();

//                ViewBag.recipe = content;
//            }
//            catch
//            {
//                ViewBag.recipe = "Tarif oluşturulamadı. API yanıtı beklenen formatta değil.";
//            }

//            return View();
//        }
//    }
//}


//using Microsoft.AspNetCore.Mvc;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace ApiPrpjeKampii.WebUI.Controllers
//{
//    public class AIController : Controller
//    {
//        public IActionResult CreateRecipeWithOpenAI()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
//        {
//            var apiKey = ""; // Gemini API anahtarın
//            using var client = new HttpClient();

//            var requestdata = new
//            {
//                contents = new[]
//                {
//                    new
//                    {
//                        parts = new[]
//                        {
//                            new
//                            {
//                                text = $"Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Kullanıcının girdiği malzemelere göre yemek tarifi öner. Tarifi başlık, malzemeler ve adımlar şeklinde bölümlere ayır: {prompt}"
//                            }
//                        }
//                    }
//                }
//            };

//            var request = new HttpRequestMessage(HttpMethod.Post,
//                $"https://generativelanguage.googleapis.com/v1/models/gemini-pro:generateContent?key={apiKey}");
//            request.Content = new StringContent(JsonSerializer.Serialize(requestdata), Encoding.UTF8, "application/json");

//            var response = await client.SendAsync(request);
//            var responseContent = await response.Content.ReadAsStringAsync();

//            try
//            {
//                using var doc = JsonDocument.Parse(responseContent);
//                var root = doc.RootElement;

//                if (root.TryGetProperty("candidates", out var candidates) &&
//                    candidates.GetArrayLength() > 0 &&
//                    candidates[0].TryGetProperty("content", out var content) &&
//                    content.TryGetProperty("parts", out var parts) &&
//                    parts.GetArrayLength() > 0 &&
//                    parts[0].TryGetProperty("text", out var textElement))
//                {
//                    var contentText = textElement.GetString();
//                    //ViewBag.recipe = contentText;
//                    // ViewBag.recipe = content; yerine şunu yaz:
//                    return Content(responseContent, "application/json");

//                }
//                else
//                {
//                    ViewBag.recipe = "Tarif oluşturulamadı. API yanıtı beklenen formatta değil.";
//                }
//            }
//            catch
//            {
//                ViewBag.recipe = "Tarif oluşturulamadı. JSON çözümleme hatası.";
//            }

//            return View();
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiPrpjeKampii.WebUI.Controllers
{
    public class AIController : Controller
    {
        public IActionResult CreateRecipeWithOpenAI()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
        {
           
            var apiKey = "AIzaSyCbw3sgF7oq29IrvTAjCx_8wl5gyWnUPhI"; // Gemini API anahtarın
            using var client = new HttpClient();
    
            var requestdata = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = $"Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Kullanıcının girdiği malzemelere göre yemek tarifi öner. Tarifi başlık, malzemeler ve adımlar şeklinde bölümlere ayır: {prompt}"
                            }
                        }
                    }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post,
    $"https://generativelanguage.googleapis.com/v1/models/gemini-2.5-pro:generateContent?key={apiKey}");

            request.Content = new StringContent(JsonSerializer.Serialize(requestdata), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return Content($"API Hatası: {response.StatusCode} - {responseContent}", "text/plain");
            }
            try
            {
                using var doc = JsonDocument.Parse(responseContent);
                var root = doc.RootElement;

                if (root.TryGetProperty("candidates", out var candidates) &&
                    candidates.GetArrayLength() > 0 &&
                    candidates[0].TryGetProperty("content", out var content) &&
                    content.TryGetProperty("parts", out var parts) &&
                    parts.GetArrayLength() > 0 &&
                    parts[0].TryGetProperty("text", out var textElement))
                {
                    var contentText = textElement.GetString();
                    ViewBag.recipe = contentText;
                }
                else
                {
                    ViewBag.recipe = "Tarif oluşturulamadı. API yanıtı beklenen formatta değil.";
                }
            }
            catch
            {
                ViewBag.recipe = "Tarif oluşturulamadı. JSON çözümleme hatası.";
            }

            return View();
        }
        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }
        public class Choice
        {
            public Message message { get; set; }
        }
        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}


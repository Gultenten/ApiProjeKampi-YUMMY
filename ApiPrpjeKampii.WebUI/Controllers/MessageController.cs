using ApiPrpjeKampii.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiProjeKampi.WebUI.Models
{
    //    public class ChatHub : Hub
    //    {
    //        private const string apiKey = "";
    //        private const string modelGpt = "gpt-4o-mini";
    //        private readonly IHttpClientFactory _httpClientFactory;
    //        public ChatHub(IHttpClientFactory httpClientFactory)
    //        {
    //            _httpClientFactory = httpClientFactory;
    //        }

    //        private static readonly Dictionary<string, List<Dictionary<string, string>>> _history = new();

    //        public override Task OnConnectedAsync()
    //        {
    //            _history[Context.ConnectionId] = new List<Dictionary<string, string>>
    //            {
    //                new Dictionary<string, string>
    //                {
    //                 ["role"] = "system",["content"] = "You are a helpful assistant. Keep answers concise."

    //                }
    //            };
    //            return base.OnConnectedAsync();
    //        }
    //        public override Task OnDisconnectedAsync(Exception? exception)
    //        {
    //            _history.Remove(Context.ConnectionId);
    //            return base.OnDisconnectedAsync(exception);
    //        }
    //        public async Task SendMessage(string userMessage)
    //        {
    //            await Clients.Caller.SendAsync("ReceiveUserEcho", userMessage);
    //            var history = _history[Context.ConnectionId];
    //            history.Add(new() { ["role"] = "user", ["content"] = userMessage });
    //            await StreamOpenAI(history, Context.ConnectionAborted);
    //        }

    //        public async Task StreamOpenAI(List<Dictionary<string, string>> history, CancellationToken cancellationToken)
    //        {
    //            var client = _httpClientFactory.CreateClient("openai");
    //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    //            var payload = new
    //            {
    //                model = modelGpt,
    //                messages = history,
    //                stream = true,
    //                temperature = 0.2
    //            };

    //            using var req = new HttpRequestMessage(HttpMethod.Post, "v1/chat/completions");
    //            req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

    //            using var resp = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
    //            resp.EnsureSuccessStatusCode();

    //            using var stream = await resp.Content.ReadAsStreamAsync(cancellationToken);
    //            using var reader = new StreamReader(stream);

    //            var sb = new StringBuilder();
    //            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
    //            {
    //                var line = await reader.ReadLineAsync();
    //                if (string.IsNullOrWhiteSpace(line)) continue;
    //                if (!line.StartsWith("data:")) continue;
    //                var data = line["data:".Length..].Trim();
    //                if (data == "[DONE]") break;

    //                try
    //                {
    //                    var chunk = JsonSerializer.Deserialize<ChatStreamChunk>(data);
    //                    var delta = chunk?.Choices?.FirstOrDefault()?.Delta?.Content;
    //                    if (!string.IsNullOrEmpty(delta))
    //                    {
    //                        sb.Append(delta);
    //                        await Clients.Caller.SendAsync("ReceiveToken", delta, cancellationToken);
    //                    }
    //                }
    //                catch
    //                {

    //                }
    //            }

    //            var full = sb.ToString();
    //            history.Add(new() { ["role"] = "assistant", ["content"] = full });
    //            await Clients.Caller.SendAsync("CompleteMessage", full, cancellationToken);
    //        }

    //        //Stream Parse Modelleri
    //        private sealed class ChatStreamChunk
    //        {
    //            [JsonPropertyName("choices")] public List<Choice>? Choices { get; set; }
    //        }
    //        private sealed class Choice
    //        {
    //            [JsonPropertyName("delta")] public Delta? Delta { get; set; }
    //            [JsonPropertyName("finish_reason")] public string? FinishReason { get; set; }
    //        }

    //        private sealed class Delta
    //        {
    //            [JsonPropertyName("content")] public string? Content { get; set; }
    //            [JsonPropertyName("role")] public string? Role { get; set; }
    //        }
    //    }
    //}
    //   using ApiPrpjeKampii.WebUI.Dtos.MessageDtos;
    //    using Microsoft.AspNetCore.Mvc;
    //    using Microsoft.AspNetCore.SignalR;
    //    using Newtonsoft.Json;
    //    using System.Net.Http.Headers;
    //    using System.Text;
    //    using System.Text.Json;
    //    using System.Text.Json.Serialization;
    //    using static ApiPrpjeKampii.WebUI.Controllers.AIController;

    //    namespace ApiProjeKampi.WebUI.Models { 
    //    public class MessageController : Controller
    //    {
    //        private readonly IHttpClientFactory _httpClientFactory;
    //        public MessageController(IHttpClientFactory httpClientFactory)
    //        {
    //            _httpClientFactory = httpClientFactory;
    //        }

    //        public async Task<IActionResult> MessageList()
    //        {
    //            var client = _httpClientFactory.CreateClient();
    //            var responseMessage = await client.GetAsync("https://localhost:7129/api/Messages");
    //            if (responseMessage.IsSuccessStatusCode)
    //            {
    //                var jsonData = await responseMessage.Content.ReadAsStringAsync();
    //                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
    //                return View(values);
    //            }
    //            return View();
    //        }

    //        [HttpGet]
    //        public IActionResult CreateMessage()
    //        {
    //            return View();
    //        }

    //        [HttpPost]
    //        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
    //        {
    //            var client = _httpClientFactory.CreateClient();
    //            var jsonData = JsonConvert.SerializeObject(createMessageDto);
    //            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    //            var responseMessage = await client.PostAsync("https://localhost:7129/api/Messages", stringContent);
    //            if (responseMessage.IsSuccessStatusCode)
    //            {
    //                return RedirectToAction("MessageList");
    //            }
    //            return View();
    //        }

    //        public async Task<IActionResult> DeleteMessage(int id)
    //        {
    //            var client = _httpClientFactory.CreateClient();
    //            await client.DeleteAsync("https://localhost:7129/api/Messages?id=" + id);
    //            return RedirectToAction("MessageList");
    //        }

    //        [HttpGet]
    //        public async Task<IActionResult> UpdateMessage(int id)
    //        {
    //            var client = _httpClientFactory.CreateClient();
    //            var responseMessage = await client.GetAsync("https://localhost:7129/api/Messages/GetMessage?id=" + id);
    //            var jsonData = await responseMessage.Content.ReadAsStringAsync();
    //            var value = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
    //            return View(value);
    //        }


    //        [HttpPost]
    //        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
    //        {
    //            var client = _httpClientFactory.CreateClient();
    //            var jsonData = JsonConvert.SerializeObject(updateMessageDto);
    //            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    //            await client.PutAsync("https://localhost:7129/api/Messages/", stringContent);
    //            return RedirectToAction("MessageList");
    //        }

    //        [HttpGet]
    //        public async Task<IActionResult> AnswerMessageWithOpenAI(int id, string prompt)
    //        {
    //            var client = _httpClientFactory.CreateClient();
    //            var responseMessage = await client.GetAsync("https://localhost:7129/api/Messages/GetMessage?id=" + id);
    //            var jsonData = await responseMessage.Content.ReadAsStringAsync();
    //            var value = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
    //            prompt = value.MessageDetails;

    //            var apiKey = "";

    //            using var client2 = new HttpClient();
    //            client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    //            var requestData = new
    //            {
    //                model = "gpt-3.5-turbo",
    //                messages = new[]
    //                {
    //                    new
    //                    {
    //                        role="system",
    //                        content="Sen bir restoran için kullanıcıların göndermiş oldukları mesajları detaylı ve olabildiğince olumlu, müşteri memnunyeti gözeten cevaplar veren bir yapay zeka aracısın. Amacımız kullanıcı tarafından gönderilen mesajlara en olumlu ve mantıklı cevapları sunabilmek."
    //                    },
    //                    new
    //                    {
    //                        role="user",
    //                        content= prompt
    //                    }
    //                },
    //                temperature = 0.5
    //            };

    //            var response = await client2.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

    //            if (response.IsSuccessStatusCode)
    //            {
    //                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
    //                var content = result.choices[0].message.content;
    //                ViewBag.answerAI = content;
    //            }
    //            else
    //            {
    //                ViewBag.answerAI = "Bir hata oluştu: " + response.StatusCode;
    //            }



    //            return View(value);
    //        }

    //        public PartialViewResult SendMessage()
    //        {
    //            return PartialView();
    //        }

    //        [HttpPost]
    //        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
    //        {

    //            var client = new HttpClient();
    //            var token = "";
    //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //            try
    //            {
    //                var translateRequestBody = new
    //                {
    //                    inputs = createMessageDto.MessageDetails
    //                };
    //                var translateJson = System.Text.Json.JsonSerializer.Serialize(translateRequestBody);
    //                var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");

    //                var translateResponse = await client.PostAsync("https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en", translateContent);
    //                var translateResponseString = await translateResponse.Content.ReadAsStringAsync();

    //                string englishText = createMessageDto.MessageDetails;
    //                if (translateResponseString.TrimStart().StartsWith("["))
    //                {
    //                    var translateDoc = JsonDocument.Parse(translateResponseString);
    //                    englishText = translateDoc.RootElement[0].GetProperty("translation_text").GetString();
    //                    //ViewBag.v = englishText;
    //                }

    //                var toxicRequestBody = new
    //                {
    //                    inputs = englishText
    //                };

    //                var toxicJson = System.Text.Json.JsonSerializer.Serialize(toxicRequestBody);
    //                var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");
    //                var toxicResponse = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", toxicContent);
    //                var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();

    //                if (toxicResponseString.TrimStart().StartsWith("["))
    //                {
    //                    var toxicDoc = JsonDocument.Parse(toxicResponseString);
    //                    foreach (var item in toxicDoc.RootElement[0].EnumerateArray())
    //                    {
    //                        string label = item.GetProperty("label").GetString();
    //                        double score = item.GetProperty("score").GetDouble();

    //                        if (score > 0.5)
    //                        {
    //                            createMessageDto.Status = "Toksik Mesaj";
    //                            break;
    //                        }
    //                    }
    //                }
    //                if (string.IsNullOrEmpty(createMessageDto.Status))
    //                {
    //                    createMessageDto.Status = "Mesaj Alındı";
    //                }
    //            }
    //            catch
    //            {
    //                createMessageDto.Status = "Onay Bekliyor";
    //            }


    //            var client2 = _httpClientFactory.CreateClient();
    //            var jsonData = JsonConvert.SerializeObject(createMessageDto);
    //            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
    //            var responseMessage = await client2.PostAsync("https://localhost:7020/api/Messages", stringContent);
    //            if (responseMessage.IsSuccessStatusCode)
    //            {
    //                return RedirectToAction("MessageList");
    //            }
    //            return View();
    //        }
    //    }
    //}
    //}










   //using ApiProjeKampi.WebUI.Dtos.MessageDtos;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using static ApiPrpjeKampii.WebUI.Controllers.AIController;

    namespace ApiProjeKampi.WebUI.Controllers
    {
        public class MessageController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public MessageController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> MessageList()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7129/api/Messages");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                    return View(values);
                }
                return View();
            }

            [HttpGet]
            public IActionResult CreateMessage()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createMessageDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7129/api/Messages", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("MessageList");
                }
                return View();
            }

            public async Task<IActionResult> DeleteMessage(int id)
            {
                var client = _httpClientFactory.CreateClient();
                await client.DeleteAsync("https://localhost:7129/api/Messages?id=" + id);
                return RedirectToAction("MessageList");
            }

            [HttpGet]
            public async Task<IActionResult> UpdateMessage(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7129/api/Messages/GetMessage?id=" + id);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(value);
            }

            [HttpPost]
            public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateMessageDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await client.PutAsync("https://localhost:7129/api/Messages/", stringContent);
                return RedirectToAction("MessageList");
            }

            [HttpGet]
            public async Task<IActionResult> AnswerMessageWithOpenAI(int id, string prompt)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7129/api/Messages/GetMessage?id=" + id);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                prompt = value.MessageDetails;


               
                var apiKey = ""; // Buraya kendi OpenAI API anahtarını yazmalısın

                using var client2 = new HttpClient();
                client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var requestData = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                    new { role="system", content="Sen bir restoran için kullanıcıların mesajlarına olumlu cevaplar veren bir yapay zekâ aracısın." },
                    new { role="user", content= prompt }
                },
                    temperature = 0.5
                };

                var response = await client2.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                    var content = result.choices[0].message.content;
                    ViewBag.answerAI = content;
                }
                else
                {
                    ViewBag.answerAI = "Bir hata oluştu: " + response.StatusCode;
                }

                return View(value);
            }

            public PartialViewResult SendMessage()
            {
                return PartialView();
            }

            [HttpPost]
            public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
            {
                var client = new HttpClient();
                ////huggingface tokenın yazıldığı  yer toksik mesaj kontrolü için
                var token = ""; // HuggingFace için token buraya yazılmalı
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var translateRequestBody = new { inputs = createMessageDto.MessageDetails };
                    var translateJson = System.Text.Json.JsonSerializer.Serialize(translateRequestBody);
                    var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");

                    var translateResponse = await client.PostAsync("https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en", translateContent);
                    var translateResponseString = await translateResponse.Content.ReadAsStringAsync();

                    string englishText = createMessageDto.MessageDetails;
                    if (translateResponseString.TrimStart().StartsWith("["))
                    {
                        var translateDoc = JsonDocument.Parse(translateResponseString);
                        englishText = translateDoc.RootElement[0].GetProperty("translation_text").GetString();
                    }

                    var toxicRequestBody = new { inputs = englishText };
                    var toxicJson = System.Text.Json.JsonSerializer.Serialize(toxicRequestBody);
                    var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");
                    var toxicResponse = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", toxicContent);
                    var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();

                    //chatgbt 
                    // 🔎 HuggingFace’den dönen cevabı görmek için
                    Console.WriteLine("Toxic Response: " + toxicResponseString);




                    if (toxicResponseString.TrimStart().StartsWith("["))
                    {
                        var toxicDoc = JsonDocument.Parse(toxicResponseString);
                        foreach (var item in toxicDoc.RootElement[0].EnumerateArray())
                        {
                            string label = item.GetProperty("label").GetString();
                            double score = item.GetProperty("score").GetDouble();

                            if (score > 0.5)
                            {
                                createMessageDto.Status = "Toksik Mesaj";
                                break;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(createMessageDto.Status))
                    {
                        Console.WriteLine("Hata oluştu: " );
                        createMessageDto.Status = "Mesaj Alındı";
                    }
                }
                catch
                {
                    createMessageDto.Status = "Onay Bekliyor";
                }

                var client2 = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createMessageDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client2.PostAsync("https://localhost:7129/api/Messages", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("MessageList");
                }
                return View();
            }
        }
    }
}

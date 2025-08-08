using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Clinic_System.PLL.Controllers
{
    [Route("ChatBot")]
    public class ChatBotController : Controller
    {
        private readonly HttpClient _httpClient;

        public ChatBotController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("ChatView")]
        public IActionResult ChatView()
        {
            return View();
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("GetResponseFromChatBot")]
        public async Task<IActionResult> GetResponseFromChatBot(IFormFile file, string sessionId, string message)
        {
            var apiUrl = "http://127.0.0.1:8000/api/chat";  // رابط الشات بوت FastAPI

            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(sessionId ?? ""), "session_id");
            formData.Add(new StringContent(message ?? ""), "message");

            if (file != null && file.Length > 0)
            {
                var fileContent = new StreamContent(file.OpenReadStream());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                formData.Add(fileContent, "file", file.FileName);
            }

            var response = await _httpClient.PostAsync(apiUrl, formData);
            var responseContent = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(responseContent);
            string botReply = json.response;

            ViewBag.BotReply = botReply;

            return Json(new { response = botReply });   // يعرض نفس الصفحة مع الرد
        }
    }
}
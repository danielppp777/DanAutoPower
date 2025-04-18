using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DanAutoPower.Models;

namespace DanAutoPower.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string ApiToken = "811f8df0-c9b4-43b7-b6f6-aff664c3901a";
        private const string ApiSecret = "8c446c9e1a42637f9b40e98fc00bdc94";
        private const string BaseUrl = "https://carapi.app/api/";
        private static string _jwtToken;

        public CarsApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // 🔐 Auth request body shape
        private class AuthRequest
        {
            public string api_token { get; set; }
            public string api_secret { get; set; }
        }

        // 🔁 Wrapper for API response format: { "data": [...] }
        private class CarApiResponse
        {
            public List<CarApiModel> data { get; set; }
        }

        // 🔐 Get and cache JWT
        private async Task<string> GetJwtToken()
        {
            if (!string.IsNullOrEmpty(_jwtToken))
                return _jwtToken;

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(BaseUrl);

            var loginPayload = new AuthRequest
            {
                api_token = ApiToken,
                api_secret = ApiSecret
            };

            var content = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("auth/login", content);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Login failed! Response: " + json);
                throw new Exception($"Login failed: {json}");
            }

            _jwtToken = json.Trim('"');
            if (string.IsNullOrEmpty(_jwtToken))
                throw new Exception("JWT was empty.");

            return _jwtToken;
        }

        // 🔎 GET: api/CarsApi/makes
        [HttpGet("makes")]
        public async Task<IActionResult> GetMakes()
        {
            var jwt = await GetJwtToken();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var response = await client.GetAsync("makes");
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("RAW JSON /makes:\n" + json);

            if (!response.IsSuccessStatusCode)
                return BadRequest($"API error: {json}");

            var parsed = JsonSerializer.Deserialize<CarApiResponse>(json);
            return Ok(parsed?.data);
        }
      
    }
}

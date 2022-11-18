using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private const string token = "PDDuWc6fB8jJ4egWq13UjJeqeLPJnYeS";

        private readonly ILogger<CurrencyController> _logger;
        private readonly HttpClient _httpClient;

        public CurrencyController(ILogger<CurrencyController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("~/getcurrency")]
        public async Task<IActionResult> GetCurrency()
        {
            _logger.LogDebug("start");
            _httpClient.DefaultRequestHeaders.Add("apikey",token);

            var response = await _httpClient.GetStringAsync($"https://api.apilayer.com/currency_data/list");
            return Ok(response);
        }


        [HttpGet("~/getlive")]
        public async Task<IActionResult> GetLiveCurrency(string currencies, string sourceCurrency)
        {
            _httpClient.DefaultRequestHeaders.Add("apikey", token);
            var responce = await _httpClient.GetStringAsync($"https://api.apilayer.com/currency_data/live?source={sourceCurrency}&currencies={currencies}");
            return Ok(responce);

        }
    }
}

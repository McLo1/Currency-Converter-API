using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using service;

namespace Controller
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/currency")]
    public class CurrencyController : ControllerBase
    {

        private readonly CurrencyService _Service;

        public CurrencyController(CurrencyService currencyService)
        {
            _Service = currencyService;
        }

        [HttpGet("{baseCurrency}")]
        public async Task<IActionResult> Get(string baseCurrency)
        {
            var data = await _Service.GetRatesAsync(baseCurrency.ToUpper());

            return Ok(data);
        }

    }
}
using System.Text.Json;
using models;

namespace service
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyApiResponse> GetRatesAsync(string baseCurrency)
        {
            var url = $"https://api.exchangerate-api.com/v4/latest/{baseCurrency}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<CurrencyApiResponse>(json, options);

            if (result == null)
                throw new Exception("Falha ao desserializar resposta da API");

            return result;
        }
    }
}
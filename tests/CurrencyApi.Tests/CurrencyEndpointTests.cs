using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using service;
using Xunit;

namespace CurrencyApi.Tests;

public class CurrencyEndpointTests
{
    [Fact]
    public async Task ConsultaPorMoedaRetornaAsTaxasDoProvedor()
    {
        using var app = new WebApplicationFactory<CurrencyService>();
        using var configuredApp = app.WithWebHostBuilder(builder =>
            builder.ConfigureTestServices(services =>
                services.AddHttpClient<CurrencyService>()
                    .ConfigurePrimaryHttpMessageHandler(() => new SimulatedRatesProvider())));
        using var client = configuredApp.CreateClient();

        using var response = await client.GetAsync("/api/v1/currency/usd");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("USD", result.GetProperty("base").GetString());
        Assert.Equal(5.25m, result.GetProperty("rates").GetProperty("BRL").GetDecimal());
    }

    private sealed class SimulatedRatesProvider : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("https://api.exchangerate-api.com/v4/latest/USD", request.RequestUri?.AbsoluteUri);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new { @base = "USD", rates = new { BRL = 5.25m } },
                    options: new JsonSerializerOptions())
            });
        }
    }
}

using StockAppApiFetchExample.ServiceContracts;
using System.Text.Json;

namespace StockAppApiFetchExample.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }


        public async Task<Dictionary<string, object>> GetStockPrice(string stockSymbol)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubApiKey"]}"),
                    Method = HttpMethod.Get
                };

                var httpResponse = await httpClient.SendAsync(httpRequestMessage);

                var stream = httpResponse.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);

                var response = reader.ReadToEnd();

                // neet to be seriolize

                var dictionaryResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (dictionaryResponse == null)
                {
                    throw new InvalidOperationException("No response from finnhub server");
                }

                if (dictionaryResponse.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(dictionaryResponse["error"]));
                }

                return dictionaryResponse;

            }


        }
    }
}

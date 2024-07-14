using API.NorwayTides.Configuration;
using API.NorwayTides.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.NorwayTides.Services
{
    public class TidalDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly TidalDataParser _parser;

        public TidalDataService(HttpClient httpClient, IOptions<APISettings> apisettings, TidalDataParser parser)
        {
            _httpClient = httpClient;
            _baseUrl = apisettings.Value.BaseUrl;
            _parser = parser;
        }

        public async Task<List<string>> GetAvailableHarborsAsync()
        {
            return await SendRequestAsync<List<string>>($"{_baseUrl}values?param=harbor",
                content => JsonConvert.DeserializeObject<List<string>>(content) ?? new List<string>());
        }

        public async Task<List<TidalData>> GetHarborDataAsync(string harbourName)
        {
            return await SendRequestAsync<List<TidalData>>($"{_baseUrl}?harbor={harbourName}",
                content => _parser.ParseTidalData(content));
        }

        private async Task<T> SendRequestAsync<T>(string url, Func<string, T> processContent)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return processContent(content);
        }
    }
}

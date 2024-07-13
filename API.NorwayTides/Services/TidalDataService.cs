using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using API.NorwayTides.Configuration;
using API.NorwayTides.Models;

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
            var response = await _httpClient.GetAsync($"{_baseUrl}values?param=harbor");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<string>>(content) ?? new List<string>();
        }

        public async Task<List<TidalData>> GetHarborDataAsync(string harbourName)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}?harbor={harbourName}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return _parser.ParseTidalData(content);
        }
    }
}

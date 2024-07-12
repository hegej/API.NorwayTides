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

        public TidalDataService(HttpClient httpClient, IOptions<APISettings> apisettings)
        {
            _httpClient = httpClient;
            _baseUrl = apisettings.Value.BaseUrl;
        }

        public async Task<List<string>> GetAvailableHarborsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}available.json");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch data. Status code: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var harborsAvailable = JsonConvert.DeserializeObject<List<HarborAvailable>>(content, jsonSerializerSettings);

            return harborsAvailable is null ? [] : [.. harborsAvailable.Select(ha => ha.Params.Harbor)];
        }
    }
}

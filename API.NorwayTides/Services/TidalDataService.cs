using API.NorwayTides.Configuration;
using API.NorwayTides.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.NorwayTides.Services
{
    public class TidalDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly ILogger<TidalDataService> _logger;
        private readonly TidalDataParser _parser;
        private readonly IMemoryCache _cache;

        public TidalDataService(HttpClient httpClient, IOptions<APISettings> apisettings, ILogger<TidalDataService> logger, TidalDataParser parser, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _baseUrl = apisettings.Value.BaseUrl;
            _logger = logger;
            _parser = parser;
            _cache = cache;
        }

        public async Task<List<string>> GetAvailableHarborsAsync()
        {
            return await _cache.GetOrCreateAsync("AvailableHarbors", async entry =>
            {
                _logger.LogInformation("Fetching available harbors from API.");
                entry.AbsoluteExpiration = GetNextNoonUtc();
                var url = $"{_baseUrl}values?param=harbor";
                return await SendRequestAsync(url, content => JsonConvert.DeserializeObject<List<string>>(content) ?? new List<string>());
            });
        }

        public async Task<List<TidalData>> GetHarborDataAsync(string harborName)
        {
            string cacheKey = $"HarborData-{harborName}";
            _logger.LogInformation($"Checking cache for data on harbor: {harborName}");

            var harborData = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpiration = GetNextNoonUtc();
                _logger.LogInformation($"Cache miss for harbor: {harborName}. Fetching from API.");
                var url = $"{_baseUrl}?harbor={harborName}";

                try
                {
                    var data = await SendRequestAsync(url, content => _parser.ParseTidalData(content));
                    _logger.LogInformation($"Data fetched and parsed for harbor: {harborName}");
                    return data;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to fetch or parse data for harbor: {harborName}");
                    throw;
                }
            });

            if (harborData != null && harborData.Any())
            {
                _logger.LogInformation($"Returning cached or fresh data for harbor: {harborName}");
                return harborData;
            }
            else
            {
                _logger.LogWarning($"No data found for harbor: {harborName}");
                return new List<TidalData>();
            }
        }


        private async Task<T> SendRequestAsync<T>(string url, Func<string, T> processContent)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return processContent(content);
        }

        private DateTimeOffset GetNextNoonUtc()
        {
            var now = DateTime.UtcNow;
            var noonToday = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0, DateTimeKind.Utc);
            if (now <= noonToday)
            {
                return noonToday;
            }
            else
            {
                return noonToday.AddDays(1);
            }
        }
    }
}


using System.Text.Json.Serialization;

namespace API.NorwayTides.Models
{
    public class HarborAvailable
    {
        [JsonPropertyName("params")]
        public HarborParams Params { get; set; }
        
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}

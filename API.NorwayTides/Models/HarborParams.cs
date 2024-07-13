using System.Text.Json.Serialization;

namespace API.NorwayTides.Models
{
    public class HarborParams
    {
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }
        
        [JsonPropertyName("datatype")]
        public string DataType { get; set; }
       
        [JsonPropertyName("harbor")]
        public string Harbor { get; set; }
    }
}

using Newtonsoft.Json;

namespace ThesareaClient.Data.Json;

public class ThesareaConfig
{
    [JsonProperty("apiurl")] public string Api { get; set; }
    [JsonProperty("token")] public string Token { get; set; }
}

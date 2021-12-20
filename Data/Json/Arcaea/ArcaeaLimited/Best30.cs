using Newtonsoft.Json;

namespace ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

[Serializable]
public class Best30
{
    [JsonProperty("data")] public List<RecordDataItem> Data { get; set; }
}

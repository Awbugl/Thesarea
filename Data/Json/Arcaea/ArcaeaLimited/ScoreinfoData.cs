using Newtonsoft.Json;

namespace ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

[Serializable]
public class ScoreinfoData
{
    [JsonProperty("data")] public RecordDataItem Data { get; set; }
}

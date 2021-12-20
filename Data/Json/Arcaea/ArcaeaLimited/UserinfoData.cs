using Newtonsoft.Json;

namespace ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

[Serializable]
public class UserinfoData
{
    [JsonProperty("data")] public UserinfoDataItem Data { get; set; }
}

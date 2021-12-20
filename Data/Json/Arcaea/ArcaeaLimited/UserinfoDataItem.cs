using Newtonsoft.Json;

namespace ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

[Serializable]
public class UserinfoDataItem
{
    [JsonProperty("display_name")] public string DisplayName { get; set; }
    [JsonProperty("potential")] public short Potential { get; set; }
    [JsonProperty("partner")] public Partner Partner { get; set; }
    [JsonProperty("last_played_song")] public RecordDataItem LastPlayedSong { get; set; }
}

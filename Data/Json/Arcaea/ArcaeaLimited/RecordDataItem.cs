using Newtonsoft.Json;

namespace ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

[Serializable]
public class RecordDataItem
{
    [JsonProperty("song_id")] public string SongId { get; set; }
    [JsonProperty("difficulty")] public sbyte Difficulty { get; set; }
    [JsonProperty("score")] public string Score { get; set; }
    [JsonProperty("shiny_pure_count")] public string ShinyPureCount { get; set; }
    [JsonProperty("pure_count")] public string PureCount { get; set; }
    [JsonProperty("far_count")] public string FarCount { get; set; }
    [JsonProperty("lost_count")] public string LostCount { get; set; }
    [JsonProperty("recollection_rate")] public int RecollectionRate { get; set; }
    [JsonProperty("time_played")] public long TimePlayed { get; set; }
    [JsonProperty("gauge_type")] public int GaugeType { get; set; }
    [JsonProperty("potential_value")] public double PotentialValue { get; set; }
}

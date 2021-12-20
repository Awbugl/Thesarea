using Newtonsoft.Json;

namespace ThesareaClient.Data.Json;

public class ThesareaApiSongData
{
    [JsonProperty("code")] public int Code { get; set; }
    [JsonProperty("message")] public string Message { get; set; }
    [JsonProperty("data")] public List<SongData> Data { get; set; }
}

public class SongData
{
    [JsonProperty("songId")] public string SongId { get; set; }
    [JsonProperty("songname")] public string Songname { get; set; }
    [JsonProperty("package")] public string Package { get; set; }
    [JsonProperty("ratings")] public List<double> Ratings { get; set; }
    [JsonProperty("notes")] public List<int> Notes { get; set; }
}

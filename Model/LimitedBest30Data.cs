using ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

namespace ThesareaClient.Model;

[Serializable]
internal class LimitedBest30Data
{
    private List<RecordInfo> _best30List;

    internal LimitedBest30Data(Best30 b30data)
    {
        B30data = b30data;
        _best30List = B30data.Data.Select(i => new RecordInfo(i)).ToList();
    }

    private Best30 B30data { get; }
    internal string Best30Avg => B30data.Data.Average(i => i.PotentialValue).ToString("0.0000");

    internal string Best30TextResult
    {
        get
        {
            var result = $"Best30 Record:  Avg={Best30Avg}";

            for (var i = 0; i < _best30List.Count; ++i)
                result
                    += $"\n\n#{i + 1}  {_best30List[i].SongInfo.Songname}\n  {_best30List[i].Score} / {_best30List[i].Rating} {_best30List[i].ConstString}\n  Pure:{_best30List[i].Pure} (+{_best30List[i].MaxPure})  Far:{_best30List[i].Far}  Lost:{_best30List[i].Lost}";

            return result;
        }
    }
}

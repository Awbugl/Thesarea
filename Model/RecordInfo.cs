using System.Text;
using ThesareaClient.Core.Api;
using ThesareaClient.Data.Json;
using ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

namespace ThesareaClient.Model;

[Serializable]
internal class RecordInfo
{
    private readonly string _score;

    internal RecordInfo(RecordDataItem recentdata, SongData? arcsong = null, sbyte difficulty = -128)
    {
        SongInfo = arcsong ?? ThesareaApi.SongAlias(recentdata.SongId).Data[0];

        Difficulty = difficulty == -128
            ? recentdata.Difficulty
            : difficulty;
        SongId = recentdata.SongId;
        Rating = recentdata.PotentialValue.ToString("0.0000");
        Pure = recentdata.PureCount;
        MaxPure = recentdata.ShinyPureCount;
        Far = recentdata.FarCount;
        Lost = recentdata.LostCount;
        Time = new DateTime(1970, 1, 1, 8, 0, 0, DateTimeKind.Utc).AddMilliseconds(recentdata.TimePlayed);

        _score = recentdata.Score;
    }

    internal SongData SongInfo { get; }

    internal sbyte Difficulty { get; }

    internal string SongId { get; }

    internal string Rating { get; }

    internal string Pure { get; }

    internal string MaxPure { get; }

    internal string Far { get; }

    internal string Lost { get; }

    internal DateTime Time { get; }

    internal string TimeStr => Time.ToString("yyyy/MM/dd HH:mm:ss");

    internal DifficultyInfo DifficultyInfo => DifficultyInfo.GetByIndex(Difficulty);

    internal double Const => SongInfo.Ratings[Difficulty];

    internal string ConstString => $"[{DifficultyInfo.ShortStr} {Const:0.0}]";

    internal string Score
    {
        get
        {
            var result = new StringBuilder();
            var len = _score.Length;
            for (var i = 0; i < 8; i++)
            {
                var j = len - 8 + i;
                result.Append(j < 0
                                  ? '0'
                                  : _score[j]);
                if (i is 1 or 4) result.Append('\'');
            }

            return result.ToString();
        }
    }

    internal string Rate
    {
        get
        {
            return Convert.ToInt32(_score) switch
                   {
                       >= 9900000 => "[EX+]",
                       >= 9800000 => "[EX]",
                       >= 9500000 => "[AA]",
                       >= 9200000 => "[A]",
                       >= 8900000 => "[B]",
                       >= 8600000 => "[C]",
                       _          => "[D]"
                   };
        }
    }

    internal bool Compare(RecordInfo? info)
    {
        if (info == null) return true;
        return Convert.ToInt32(_score) > Convert.ToInt32(info._score);
    }
}

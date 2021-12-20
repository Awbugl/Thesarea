using ThesareaClient.Core.Api;
using ThesareaClient.Data.Json;
using ThesareaClient.Model;

namespace ThesareaClient.Core.Utils;

internal static class ArcaeaHelper
{
    internal static (DifficultyInfo?, ThesareaApiSongData?) Converter(IEnumerable<string> command)
    {
        var enumerable = command.ToArray();

        if (enumerable.Length == 0) return (null, null);

        var (songstr, difinfo) = DifficultyInfo.DifficultyConverter(enumerable.Last());

        var song = string.Join("", enumerable, 0, enumerable.Length - 1) + songstr;

        return (difinfo, ThesareaApi.SongAlias(song));
    }
}

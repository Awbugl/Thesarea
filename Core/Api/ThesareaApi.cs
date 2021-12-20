using Newtonsoft.Json;
using ThesareaClient.Data.Json;

namespace ThesareaClient.Core.Api;

internal static class ThesareaApi
{
    private const string Api = "https://server.awbugl.top";

    private static readonly HttpClient Client;

    static ThesareaApi() { Client = new(); }

    private static string GetString(string url) => Client.GetStringAsync(url).GetAwaiter().GetResult();


    internal static ThesareaApiSongData SongAlias(string alias) =>
        JsonConvert.DeserializeObject<ThesareaApiSongData>(GetString($"{Api}/song?alias={alias}"))!;
}

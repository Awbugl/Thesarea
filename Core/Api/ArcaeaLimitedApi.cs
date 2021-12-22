using Newtonsoft.Json;
using ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

namespace ThesareaClient.Core.Api;

internal static class ArcaeaLimitedApi
{
    private static HttpClient Client;
    private static bool _inited;


    private static void Init()
    {
        Client = new();
        Client.DefaultRequestHeaders.Authorization = new("Bearer", Token);
    }

    internal static string Api { get; set; }
    internal static string Token { get; set; }

    private static string GetString(string url)
    {
        if (!_inited)
        {
            Init();
            _inited = true;
        }

        return Client.GetStringAsync(url).GetAwaiter().GetResult();
    }

    internal static UserinfoDataItem? Userinfo(long uid) =>
        JsonConvert.DeserializeObject<UserinfoData>(GetString($"{Api}/user/{uid:D9}"))?.Data;

    internal static RecordDataItem? RecordInfo(long uid, string sid, sbyte dif) =>
        JsonConvert
            .DeserializeObject<ScoreinfoData>(GetString($"{Api}/user/{uid:D9}/score?song_id={sid}&difficulty={dif}"))
            ?.Data;

    internal static Best30? Userbest30(long uid) =>
        JsonConvert.DeserializeObject<Best30>(GetString($"{Api}/user/{uid:D9}/best"));
}

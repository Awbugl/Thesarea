using ThesareaClient.Data.Json.Arcaea.ArcaeaLimited;

namespace ThesareaClient.Model;

[Serializable]
internal class PlayerInfo
{
    internal PlayerInfo(UserinfoDataItem recentdata)
    {
        PlayerName = recentdata.DisplayName;
        Partner = recentdata.Partner.PartnerId + (recentdata.Partner.IsAwakened
            ? "u"
            : "");
        Potential = ((double)recentdata.Potential / 100).ToString("0.00");
    }

    internal string PlayerName { get; }

    internal string Partner { get; }

    internal string Potential { get; }
}

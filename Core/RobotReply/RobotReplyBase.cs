using System.Net;
using ThesareaClient.Data.Json;

namespace ThesareaClient.Core.RobotReply;

[Serializable]
internal abstract class RobotReplyBase
{
    internal string NotBind { get; set; }
    internal string NotBindArc { get; set; }
    internal string NotBindOsu { get; set; }
    internal string NotBindPjsk { get; set; }
    internal string PleasePrivateMessage { get; set; }
    internal string ParameterLengthError { get; set; }
    internal string ParameterError { get; set; }
    internal string ConfigNotFound { get; set; }
    internal string NotPlayedTheSong { get; set; }
    internal string OsuUserBindFailed { get; set; }
    internal string OsuModeConvertFailed { get; set; }
    internal string OsuRecentNotPlayed { get; set; }
    internal string ArcUidNotFound { get; set; }
    internal string TooManyArcUid { get; set; }
    internal string NoSongFound { get; set; }
    internal string NoBydChart { get; set; }
    internal string NotPlayedTheChart { get; set; }
    internal string GotShadowBanned { get; set; }
    internal string DismissMessage { get; set; }
    internal Func<List<SongData>, string> TooManySongFound { get; set; }
    internal Func<int, string, string> ArcApiQueryFailed { get; set; }
    internal Func<string, string> JrrpResult { get; set; }
    internal Func<string, string> SendMessageFailed { get; set; }
    internal Func<string, string> MainBotChange { get; set; }
    internal Func<string, string> BindSuccess { get; set; }
    internal Func<string, string> RandSongReply { get; set; }

    internal Func<WebException, string> WebQueryFailed { get; set; }
    internal Func<Exception, string> ExceptionOccured { get; set; }
}

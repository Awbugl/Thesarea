using System.Net;
using ThesareaClient.Data.Json;

namespace ThesareaClient.Core.RobotReply;

[Serializable]
internal abstract class RobotReplyBase
{
    internal string NotBind { get; set; }
    internal string NotBindArc { get; set; }
    internal string PleasePrivateMessage { get; set; }
    internal string ParameterLengthError { get; set; }
    internal string ParameterError { get; set; }
    internal string ArcUidNotFound { get; set; }
    internal string NoSongFound { get; set; }
    internal Func<List<SongData>, string> TooManySongFound { get; set; }
    internal Func<string, string> BindSuccess { get; set; }
    internal Func<WebException, string> WebQueryFailed { get; set; }
    internal Func<Exception, string> ExceptionOccured { get; set; }
}

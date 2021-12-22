using System.Net;

namespace ThesareaClient.Core.RobotReply;

[Serializable]
internal class AndreaReply : RobotReplyBase
{
    public AndreaReply()
    {
        NotBind = "数据库中没有您的数据。请先绑定一个arc账号，否则这边没办法提供服务。";
        NotBindArc = "数据库中没有您的数据。请先发送指令 /a bind 您的Arcuid 以绑定，否则这边没办法提供服务。";
        PleasePrivateMessage = "这条指令的回复有点长，为避免对其他人造成干扰，请在私聊中查询。";
        ParameterLengthError = "参数长度错误，请检查是否按照用户手册进行。";
        ParameterError = "参数格式错误，请检查是否按照用户手册进行。";
        ArcUidNotFound = "查询失败。抱歉，并没有在数据库中找到您的UID。";
        NoSongFound = "您提交的关键词在数据库中没有对应的曲目。";
        WebQueryFailed = ex => $"服务器连接失败，请稍后再发送一次请求。({ex.Message})";
        TooManySongFound = ls => ls.Aggregate("您提交的关键词在数据库中对应的曲目过多，请更换更为精确的关键词再次查询：", (cur, i) => cur + "\n" + i.Songname);
        BindSuccess = info => $"{info}的信息已经存入数据库啦。";
        ExceptionOccured = ex => ex switch
                                 {
                                     WebException webexception => WebQueryFailed(webexception),
                                     _ => $"连接服务器时发生了未预料的数据错误，请稍后重试。\n({ex.Message})"
                                 };
    }
}

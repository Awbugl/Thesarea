using System.Net;

namespace ThesareaClient.Core.RobotReply;

[Serializable]
internal class AndreaReply : RobotReplyBase
{
    public AndreaReply()
    {
        NotBind = "数据库中没有您的数据呢。请先绑定一个arc/osu账号，否则这边没办法提供服务。";
        NotBindArc = "数据库中没有您的数据呢。请先发送指令 /a bind 您的Arc用户名/uid 以绑定，否则这边没办法提供服务。";
        NotBindOsu = "数据库中没有您的数据呢。请先发送指令 /o bind 您的Osu!用户名/uid 以绑定，否则这边没办法提供服务。";
        NotBindPjsk = "数据库中没有您的数据呢。请先发送指令 /p bind 您的PjskUid 以绑定，否则这边没办法提供服务。";
        PleasePrivateMessage = "这条指令的回复有点长哦，为避免对其他人造成干扰，请在私聊中查询。";
        ParameterLengthError = "参数长度错误了呢，请检查是否按照用户手册进行。";
        ParameterError = "参数格式错误了呢，请检查是否按照用户手册进行。";
        ConfigNotFound = "没有找到这条指令呢，请检查一下用户手册。";
        NotPlayedTheSong = "您目前尚未游玩该曲目。";
        OsuUserBindFailed = "您的Osu账号绑定失败了，请检查一下用户名和是否选择了常用模式。";
        OsuModeConvertFailed = "输入的Osu模式错误了呢，识别不出来哦。";
        OsuRecentNotPlayed = "数据库请求错误，您最近24小时内未游玩此模式的谱面。";
        ArcUidNotFound = "查询失败。抱歉，并没有在系统中找到您绑定的UID呢。";
        TooManyArcUid = "您提交的用户名在数据库中对应的UID不唯一，请使用UID进行绑定。";
        NoSongFound = "您提交的关键词在数据库中没有对应的曲目。";
        NoBydChart = "诶唔，该曲目不存在Byd谱面哦。";
        NotPlayedTheChart = "您目前尚未游玩该谱面。(也可能是您的排行榜被封禁，请联系Lowiro解封.)";
        GotShadowBanned = "您的排行榜被封禁，请联系Lowiro解封.";
        ArcApiQueryFailed = (status, message) => $"抱歉，请稍等，我需要把数据库接口修一下。({status}: {message})";
        WebQueryFailed = ex => $"数据库连接失败，请稍后再发送一次请求。({ex.Message})";
        TooManySongFound = ls => ls.Aggregate("您提交的关键词在数据库中对应的曲目过多，请更换更为精确的关键词：", (cur, i) => cur + "\n" + i.Songname);
        JrrpResult = jrrp => $"数据分析中心预测，您今天有{jrrp}%的概率收掉想收的曲子。";
        SendMessageFailed = name => $"{name}想交给你的数据出错了，请稍等一下再来拿吧。";
        MainBotChange = name => $"以后本群的数据就由{name}接手啦。";
        BindSuccess = info => $"{info}的信息已经存入研究所数据库啦。";
        RandSongReply = info => $"您可以尝试挑战\n{info}";
        DismissMessage = "那我就先离开啦，下次再见。";
        ExceptionOccured = ex => ex switch
                                 {
                                     WebException webexception => WebQueryFailed(webexception),
                                     AggregateException exception =>
                                         WebQueryFailed((exception.InnerException as WebException)!),
                                     _ => $"数据库内发生了未预料的数据错误，请稍后重试。\n({ex.Message})"
                                 };
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using ThesareaClient.Core.Api;
using ThesareaClient.Core.Model;
using ThesareaClient.Core.RobotReply;
using ThesareaClient.Core.Utils;
using ThesareaClient.Data;
using ThesareaClient.Data.Json;
using ThesareaClient.Model;

namespace ThesareaClient.Core.Executor;

[Serializable]
internal class ArcExecutor : ExecutorBase
{
    public ArcExecutor(MessageInfo info) : base(info) { }

    [CommandPrefix("/arc bind ")]
    private string Bind()
    {
        try
        {
            if (CommandLength != 1) return RobotReply.ParameterLengthError;

            if (!long.TryParse(Command[0], out var iuid)) return RobotReply.ParameterError;
            var userinfo = ArcaeaLimitedApi.Userinfo(iuid);
            var user = User ?? new BotUserInfo { QqId = Info.FromQq };
            user.ArcId = iuid;
            BotUserInfo.Set(user);

            return
                RobotReply.BindSuccess($"{userinfo!.DisplayName} ({(userinfo.Potential == -1 ? "--" : ((double)userinfo.Potential / 100).ToString("0.00"))})");
        }
        catch (WebException e)
        {
            if (((HttpWebResponse)e.Response!).StatusCode == HttpStatusCode.NotFound) return RobotReply.ArcUidNotFound;
            return RobotReply.ExceptionOccured(e);
        }
        catch (Exception e)
        {
            return RobotReply.ExceptionOccured(e);
        }
    }


    [CommandPrefix("/arc b30")]
    private string Best30()
    {
        if (User == null) return RobotReply.NotBind;
        if (User.ArcId < 2) return RobotReply.NotBindArc;

        var b30data = new LimitedBest30Data(ArcaeaLimitedApi.Userbest30(User.ArcId)!);

        return IsGroup
            ? RobotReply.PleasePrivateMessage
            : b30data.Best30TextResult;
    }

    private string Recent()
    {
        var recentdata = ArcaeaLimitedApi.Userinfo(User!.ArcId);
        var recordInfo = new RecordInfo(recentdata!.LastPlayedSong);
        return new RecordData(new(recentdata), recordInfo).GetResult();
    }

    [CommandPrefix("/arc info ")]
    private string Search()
    {
        if (User == null) return RobotReply.NotBind;
        if (User.ArcId < 2) return RobotReply.NotBindArc;

        if (CommandLength == 0) return Recent();
        if (Command[0] == "b30") return Best30();

        var (dif, result) = ArcaeaHelper.Converter(Command);

        if (result is null) return RobotReply.ParameterError;

        if (result.Code != 0) return GetSongAliasErrorMessage(RobotReply, result.Code, result.Data)!;
        var arcsong = result.Data[0];

        var recentdata = ArcaeaLimitedApi.Userinfo(User.ArcId);
        var userbest = new RecordInfo(ArcaeaLimitedApi.RecordInfo(User.ArcId, arcsong.SongId, dif!)!, arcsong, dif!);
        return new RecordData(new(recentdata!), userbest).GetResult();
    }

    internal static string? GetSongAliasErrorMessage(RobotReplyBase info, int status, List<SongData> ls)
    {
        return status switch
               {
                   -2 => info.NoSongFound,
                   -3 => info.TooManySongFound(ls),
                   _  => null
               };
    }
}

using System.Net;
using System.Reflection;
using ThesareaClient.Core.RobotReply;
using ThesareaClient.Data;

namespace ThesareaClient.Core.Model;

[Serializable]
internal class MessageInfo
{
    private static readonly ObjectPool<MessageInfo> Objpool = new();

    internal long FromGroup { get; private set; }
    internal long FromQq { get; private set; }
    internal string[] CommandWithoutPrefix { get; private set; }
    internal MessageInfoType MessageType { get; private set; }
    private string ReplyMessage { get; set; }

    internal Lazy<BotUserInfo?> UserInfo => new(() => BotUserInfo.Get(FromQq));

    internal RobotReplyBase RobotReply => new AndreaReply();

    private string Process(Type executor, MethodInfo method)
    {
        try
        {
            ReplyMessage = (method.Invoke(Activator.CreateInstance(executor, this), null) as string)!;
        }
        catch (TargetInvocationException e)
        {
            ReplyMessage = e.InnerException is WebException exception
                ? RobotReply.WebQueryFailed(exception)
                : RobotReply.ExceptionOccured(e.InnerException!);
            Reporter.ExceptionReport(e.InnerException!, FromQq, CommandWithoutPrefix);
        }
        catch (Exception e)
        {
            ReplyMessage = e is WebException exception
                ? RobotReply.WebQueryFailed(exception)
                : RobotReply.ExceptionOccured(e);
            Reporter.ExceptionReport(e, FromQq, CommandWithoutPrefix);
        }
        finally
        {
            Objpool.Return(this);
        }

        return ReplyMessage;
    }

    public static string Process(MessageInfoType messageType, long fromGroup, long fromQq, Type executor,
                                 MethodInfo method, string[] commandwithoutprefix)
    {
        var info = Objpool.Get();
        info.MessageType = messageType;
        info.CommandWithoutPrefix = commandwithoutprefix;
        info.FromQq = fromQq;
        info.FromGroup = fromGroup;
        return info.Process(executor, method);
    }
}

internal enum MessageInfoType
{
    Friend = 0,
    Group = 1,
    Temp = 2
}

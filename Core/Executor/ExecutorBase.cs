using ThesareaClient.Core.Model;
using ThesareaClient.Core.RobotReply;
using ThesareaClient.Data;

namespace ThesareaClient.Core.Executor;

[Serializable]
internal abstract class ExecutorBase
{
    protected readonly MessageInfo Info;

    protected ExecutorBase(MessageInfo info) { Info = info; }

    protected bool IsGroup => Info.MessageType == MessageInfoType.Group;
    protected string[] Command => Info.CommandWithoutPrefix;
    protected int CommandLength => Info.CommandWithoutPrefix.Length;
    protected BotUserInfo? User => Info.UserInfo.Value;
    protected RobotReplyBase RobotReply => Info.RobotReply;
}

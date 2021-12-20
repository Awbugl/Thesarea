using System.Reflection;
using ThesareaClient.Core.Executor;

namespace ThesareaClient.Core.Model;

[Serializable]
internal class MessagePretreater
{
    private static readonly ObjectPool<MessagePretreater> Objpool = new();

    private static readonly Dictionary<(Type, MethodInfo), string[]> MethodPrefixs = GetMethodPrefixs();

    private static readonly Dictionary<string, string> AbbreviationPairs = new() { { "/a ", "/arc " } };

    private MessageInfoType Type { get; set; }
    private long FromGroup { get; set; }
    private long FromQq { get; set; }
    private string Message { get; set; }

    internal static string Process(int type, long fromGroup, long fromQq, string message)
    {
        var tpe = (MessageInfoType)type;
        var pretreater = Objpool.Get();

        pretreater.Type = tpe;
        pretreater.FromGroup = fromGroup;
        pretreater.FromQq = fromQq;
        pretreater.Message = message;
        return pretreater.Process()!;
    }

    private static void WaitCallbackProcess(object info) { (info as MessagePretreater)?.Process(); }

    private static Dictionary<(Type, MethodInfo), string[]> GetMethodPrefixs()
    {
        var ls = new Dictionary<(Type, MethodInfo), string[]>();

        foreach (var type in Assembly.GetExecutingAssembly().DefinedTypes
                                     .Where(i => i.BaseType == typeof(ExecutorBase)))
            foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic
                                                   | BindingFlags.Public))
            {
                var prefixs = (method.GetCustomAttribute(typeof(CommandPrefixAttribute)) as CommandPrefixAttribute)
                    ?.Prefixs;
                if (prefixs != null) ls.Add((type, method), prefixs);
            }

        return ls;
    }

    private string? Process()
    {
        try
        {
            var rMsg = Replace(Message);

            foreach (var pair in MethodPrefixs)
            {
                var match = pair.Value.FirstOrDefault(j => rMsg.StartsWith(j, StringComparison.OrdinalIgnoreCase));
                if (match != default)
                {
                    var (executor, method) = pair.Key;
                    return MessageInfo.Process(Type, FromGroup, FromQq, executor, method,
                                               rMsg.Substring(match.Length)
                                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
        }
        finally
        {
            Objpool.Return(this);
        }

        return null;
    }

    private static string Replace(string rawMessage)
    {
        rawMessage = rawMessage.Trim();
        switch (rawMessage)
        {
            case "查分":
            case "查最近":
            case "查":
            case "/a":
            case "/arc":
                return "/arc info ";
        }

        foreach (var (key, value) in
                 AbbreviationPairs.Where(i => rawMessage.StartsWith(i.Key, StringComparison.OrdinalIgnoreCase)))
            rawMessage = value + rawMessage.Substring(key.Length);

        return string.Join(" ",
                           rawMessage.Split(new char[] { '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries));
    }
}

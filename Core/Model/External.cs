using ThesareaClient.Core.Utils;

namespace ThesareaClient.Core.Model;

[Serializable]
public static class External
{
    private static volatile bool _cacheCompleted;

    public static void ExceptionReport(Exception ex) { Reporter.ExceptionReport(ex); }

    public static string Process(int type, long fromGroup, long fromQq, string message) =>
        MessagePretreater.Process(type, fromGroup, fromQq, message);

    public static void Initialize()
    {
        if (_cacheCompleted) return;
        SystemHelper.Init();
        _cacheCompleted = true;
    }

    public static void Deinitialize() { _cacheCompleted = false; }
}

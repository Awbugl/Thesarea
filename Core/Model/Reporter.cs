namespace ThesareaClient.Core.Model;

internal static class Reporter
{
    internal static void ExceptionReport(Exception ex, long qqid = -1, string[] raw = null)
    {
        try
        {
            // if (ex is not WebException)
            File.AppendAllText(Path.ExceptionReport,
                               $"{DateTime.Now}\n{ex}\n来源：{qqid}{(raw is null ? "" : $"\t指令：{string.Join(" ", raw)}")}\n\n");
        }
        catch
        {
            Thread.Sleep(2000);
            ExceptionReport(ex, qqid, raw);
        }
    }
}

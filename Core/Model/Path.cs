namespace ThesareaClient.Core.Model;

[Serializable]
internal class Path
{
    private const string OtherRoot = "/Thesarea/";

    internal static readonly Path Database = new(OtherRoot + "Thesarea.db");

    internal static readonly Path ExceptionReport = new(OtherRoot + "ExceptionReport.txt");

    internal static readonly Path Config = new(OtherRoot + "ThesareaConfig.json");

    private readonly string _rawpath;

    private Path(string rawpath) { _rawpath = rawpath; }

    internal bool FileExists => File.Exists(AppContext.BaseDirectory + _rawpath);


    public static void Initialize()
    {
        if (!Directory.Exists(OtherRoot)) Directory.CreateDirectory(OtherRoot);
    }

    public static implicit operator string(Path path) => AppContext.BaseDirectory + path._rawpath;
}

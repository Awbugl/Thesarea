using System.Net;
using Newtonsoft.Json;
using ThesareaClient.Core.Api;
using ThesareaClient.Data.Json;
using Path = ThesareaClient.Core.Model.Path;

namespace ThesareaClient.Core.Utils;

internal static class SystemHelper
{
    public static void Init()
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        ServicePointManager.ServerCertificateValidationCallback = (_, _, _, _) => true;
        ServicePointManager.DefaultConnectionLimit = 512;
        ServicePointManager.Expect100Continue = false;
        ServicePointManager.UseNagleAlgorithm = false;
        ServicePointManager.ReusePort = true;
        ServicePointManager.CheckCertificateRevocationList = true;
        WebRequest.DefaultWebProxy = null;

        Path.Initialize();

        if (!File.Exists(Path.Config))
        {
            File.WriteAllText(Path.Config,
                              "{\"apiurl\": \"https://exampleapi.example.com/api/v0\",\"token\": \"your token\"");
            Console.WriteLine("ThesareaConfig默认配置文件已生成，请修改 ThesareaConfig.json 后重新启动!");
            Environment.Exit(-1);
        }

        var config = JsonConvert.DeserializeObject<ThesareaConfig>(File.ReadAllText(Path.Config));

        ArcaeaLimitedApi.Api = config!.Api;
        ArcaeaLimitedApi.Token = config.Token;

        //SqliteHelper.TryCreateTable();
    }
}

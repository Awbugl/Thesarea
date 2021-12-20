using Sora;
using Sora.Net.Config;
using ThesareaClient.Core.Model;
using YukariToolBox.LightLog;

Log.LogConfiguration.EnableConsoleOutput().SetLogLevel(LogLevel.Info);

ushort port;
var configpth = System.IO.Path.Combine(AppContext.BaseDirectory, "Thesarea/");
if (File.Exists(configpth + "portconfig"))
    port = ushort.Parse(File.ReadAllText(configpth + "portconfig"));
else
{
    Console.Write("请输入WebSocket端口(1 - 65535,不建议使用常用端口如80,443等):    ");
    port = ushort.Parse(Console.ReadLine()!);
    Directory.CreateDirectory(configpth);
    File.WriteAllText(configpth + "portconfig", port.ToString());
}

var service = SoraServiceFactory.CreateService(new ServerConfig { Port = port });

service.Event.OnGroupMessage += async (_, eventArgs) =>
                                {
                                    var reply = External.Process(1, eventArgs.SourceGroup, eventArgs.Sender,
                                                                 eventArgs.Message.GetText());
                                    await eventArgs.Reply(reply);
                                };

service.Event.OnPrivateMessage += async (_, eventArgs) =>
                                  {
                                      var reply = External.Process(eventArgs.IsTemporaryMessage
                                                                       ? 2
                                                                       : 0, 0, eventArgs.Sender,
                                                                   eventArgs.Message.GetText());
                                      await eventArgs.Reply(reply);
                                  };

//连接事件
service.ConnManager.OnOpenConnectionAsync += (connectionId, eventArgs) =>
                                             {
                                                 Log.Debug("Thesarea|OnOpenConnectionAsync",
                                                           $"connectionId = {connectionId} type = {eventArgs.Role}");
                                                 return ValueTask.CompletedTask;
                                             };
//连接关闭事件
service.ConnManager.OnCloseConnectionAsync += (connectionId, eventArgs) =>
                                              {
                                                  Log.Debug("Thesarea|OnCloseConnectionAsync",
                                                            $"uid = {eventArgs.SelfId} connectionId = {connectionId} type = {eventArgs.Role}");
                                                  return ValueTask.CompletedTask;
                                              };
//连接成功元事件
service.Event.OnClientConnect += (_, _) =>
                                 {
                                     Log.Info("Thesarea", "");
                                     Log.Info("Thesarea|Message", "交流群 191234485");
                                     Log.Info("Thesarea", "");
                                     External.Initialize();
                                     return ValueTask.CompletedTask;
                                 };


await service.StartService();

await Task.Delay(-1);

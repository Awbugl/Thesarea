using SQLite;
using ThesareaClient.Core.Model;
using ThesareaClient.Core.Utils;

namespace ThesareaClient.Data;

[Serializable]
[Table("BotUserInfo")]
[CreateTableSql("CREATE TABLE IF NOT EXISTS BotUserInfo(" + "QQId INTEGER PRIMARY KEY NOT NULL, "
                                                          + "ArcId INTEGER DEFAULT(-1), "
                                                          + "IsHide INTEGER DEFAULT(0));")]
internal class BotUserInfo
{
    private static Lazy<Dictionary<long, BotUserInfo>> _list
        = new(() => SqliteHelper.SelectAll<BotUserInfo>().ToDictionary(i => i.QqId));

    [PrimaryKey] [Column("QQId")] public long QqId { get; set; }
    [Column("ArcId")] public long ArcId { get; set; }
    [Column("IsHide")] public int IsHide { get; set; }

    internal static void Init() { _list = new(() => SqliteHelper.SelectAll<BotUserInfo>().ToDictionary(i => i.QqId)); }

    internal static void Set(BotUserInfo user)
    {
        if (_list.Value.ContainsKey(user.QqId))
        {
            _list.Value[user.QqId] = user;
            SqliteHelper.Update(user);
        }
        else
        {
            _list.Value.Add(user.QqId, user);
            SqliteHelper.Insert(user);
        }
    }

    internal static BotUserInfo? Get(long qqid) =>
        _list.Value.TryGetValue(qqid, out var user)
            ? user
            : null;
}

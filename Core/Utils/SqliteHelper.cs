using System.Reflection;
using SQLite;
using ThesareaClient.Core.Model;
using Path = ThesareaClient.Core.Model.Path;

namespace ThesareaClient.Core.Utils;

internal static class SqliteHelper
{
    private static readonly Lazy<SQLiteConnection> DbConnection
        = new(() => new(Path.Database, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex));

    internal static void Execute<T>(string command) where T : new() { DbConnection.Value.Query<T>(command); }

    internal static IEnumerable<T> SelectAll<T>() where T : new() => DbConnection.Value.Table<T>();

    internal static void Insert<T>(T obj) where T : new() { DbConnection.Value.Insert(obj); }

    internal static void DeleteByKey<T>(object primaryKey) { DbConnection.Value.Delete<T>(primaryKey); }

    internal static void Update<T>(T obj) where T : new() { DbConnection.Value.Update(obj); }

    internal static void TryCreateTable()
    {
        foreach (var (type, sql) in Assembly.GetExecutingAssembly().DefinedTypes
                                            .Where(i => i.GetCustomAttribute<CreateTableSqlAttribute>() != null)
                                            .Select(type => (
                                                        type, type.GetCustomAttribute<CreateTableSqlAttribute>().Sql)))
            typeof(SqliteHelper).GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Static)
                                ?.MakeGenericMethod(type).Invoke(type, new object[] { sql });
    }
}

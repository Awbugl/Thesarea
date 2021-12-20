namespace ThesareaClient.Model;

[Serializable]
internal class DifficultyInfo
{
    private static readonly List<DifficultyInfo> List = new()
                                                        {
                                                            new(3, "Beyond", "BYD", new[] { "byn", "byd", "beyond" }),
                                                            new(2, "Future", "FTR", new[] { "ftr", "future" }),
                                                            new(1, "Present", "PRS", new[] { "prs", "present" }),
                                                            new(0, "Past", "PST", new[] { "pst", "past" })
                                                        };

    public DifficultyInfo(sbyte index, string longStr, string shortStr, string[] alias)
    {
        Index = index;
        Alias = alias;
        LongStr = longStr;
        ShortStr = shortStr;
    }

    private sbyte Index { get; set; }
    private string[] Alias { get; set; }
    internal string LongStr { get; private set; }
    internal string ShortStr { get; private set; }
    internal static DifficultyInfo GetByIndex(int index) { return List.FirstOrDefault(i => i.Index == index)!; }

    internal static (string, DifficultyInfo) DifficultyConverter(string dif)
    {
        foreach (var info in List)
            foreach (var alias in info.Alias.Where(dif.EndsWith))
                return (dif.Substring(0, dif.Length - alias.Length), info);

        return (dif, List[1]);
    }

    public static implicit operator string(DifficultyInfo info) => info.ShortStr;

    public static implicit operator sbyte(DifficultyInfo info) => info.Index;
}

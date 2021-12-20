namespace ThesareaClient.Model;

[Serializable]
internal class RecordData
{
    internal RecordData(PlayerInfo playerInfo, RecordInfo recordInfo)
    {
        PlayerInfo = playerInfo;
        RecordInfo = recordInfo;
    }

    private PlayerInfo PlayerInfo { get; }
    private RecordInfo RecordInfo { get; }

    internal string GetResult() =>
        $"{PlayerInfo.PlayerName} ({PlayerInfo.Potential})\n  {RecordInfo.SongInfo.Songname} {RecordInfo.ConstString}\n  {RecordInfo.Score}  {RecordInfo.Rate}\n  Pure:{RecordInfo.Pure} (+{RecordInfo.MaxPure})  Far:{RecordInfo.Far}  Lost:{RecordInfo.Lost}\n  Played at  {RecordInfo.TimeStr}";
}

using System.Collections;

namespace ThesareaClient.Core.Model;

internal class SongInfoCollection : IEnumerable<SongInfoCollection.ISongInfo>
{
    private readonly ISongInfo[] _infos;
    private SongInfoCollection(ISongInfo[] infos) { _infos = infos; }

    public IEnumerator<ISongInfo> GetEnumerator() => ((IEnumerable<ISongInfo>)_infos).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _infos.GetEnumerator();

    public static implicit operator SongInfoCollection(ISongInfo[] infos) => new(infos);

    internal interface ISongInfo { }
}

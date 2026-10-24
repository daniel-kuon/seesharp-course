/// <summary>
/// Ein Strom über einem MemoryStream, der mitzählt, wie oft Dispose und Flush aufgerufen wurden,
/// und der die Reihenfolge der Freigaben in ein gemeinsames Protokoll schreibt.
/// </summary>
public sealed class ZaehlenderStrom : Stream
{
    readonly MemoryStream _innen;
    readonly string _name;
    readonly List<string> _protokoll;

    public ZaehlenderStrom(string name, List<string>? protokoll = null, byte[]? inhalt = null)
    {
        _name = name;
        _protokoll = protokoll ?? new List<string>();
        _innen = inhalt is null ? new MemoryStream() : new MemoryStream(inhalt);
    }

    public int DisposeAufrufe { get; private set; }
    public int FlushAufrufe { get; private set; }
    public bool WerfeBeimSchreiben { get; set; }
    public bool WerfeBeimLesen { get; set; }

    /// <summary>Inhalt, auch nachdem der Strom freigegeben wurde.</summary>
    public byte[] Inhalt => _innen.ToArray();

    public override bool CanRead => true;
    public override bool CanSeek => true;
    public override bool CanWrite => true;
    public override long Length => _innen.Length;
    public override long Position { get => _innen.Position; set => _innen.Position = value; }

    public override void Flush()
    {
        FlushAufrufe++;
        _innen.Flush();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (WerfeBeimLesen) throw new IOException("Lesefehler");
        return _innen.Read(buffer, offset, count);
    }

    public override long Seek(long offset, SeekOrigin origin) => _innen.Seek(offset, origin);
    public override void SetLength(long value) => _innen.SetLength(value);

    public override void Write(byte[] buffer, int offset, int count)
    {
        if (WerfeBeimSchreiben) throw new IOException("Platte voll");
        _innen.Write(buffer, offset, count);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            DisposeAufrufe++;
            _protokoll.Add("dispose:" + _name);
        }
        base.Dispose(disposing);
    }
}

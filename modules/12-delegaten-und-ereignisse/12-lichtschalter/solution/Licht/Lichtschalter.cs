public class Lichtschalter
{
    public bool IstAn { get; private set; }

    public event EventHandler? Eingeschaltet;
    public event EventHandler? Ausgeschaltet;

    public void Umschalten()
    {
        IstAn = !IstAn;
        if (IstAn)
            Eingeschaltet?.Invoke(this, EventArgs.Empty);
        else
            Ausgeschaltet?.Invoke(this, EventArgs.Empty);
    }
}

public class Lampe
{
    private readonly Lichtschalter _schalter;

    public int Einschaltungen { get; private set; }
    public int Ausschaltungen { get; private set; }

    public Lampe(Lichtschalter schalter)
    {
        _schalter = schalter;
        _schalter.Eingeschaltet += BeiEin;
        _schalter.Ausgeschaltet += BeiAus;
    }

    public void Abkoppeln()
    {
        _schalter.Eingeschaltet -= BeiEin;
        _schalter.Ausgeschaltet -= BeiAus;
    }

    private void BeiEin(object? sender, EventArgs e) => Einschaltungen++;

    private void BeiAus(object? sender, EventArgs e) => Ausschaltungen++;
}

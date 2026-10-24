public class Lichtschalter
{
    public bool IstAn { get; private set; }

    // TODO: Aus den öffentlichen Delegatenfeldern echte Ereignisse (event) machen
    public EventHandler? Eingeschaltet;
    public EventHandler? Ausgeschaltet;

    // TODO: IstAn umkehren, danach das passende Ereignis auslösen (?.Invoke(this, EventArgs.Empty))
    public void Umschalten() => throw new NotImplementedException();
}

public class Lampe
{
    private readonly Lichtschalter _schalter;

    public int Einschaltungen { get; private set; }
    public int Ausschaltungen { get; private set; }

    // TODO: _schalter merken und BeiEin / BeiAus an den beiden Ereignissen anmelden
    public Lampe(Lichtschalter schalter) => throw new NotImplementedException();

    // TODO: beide Behandlungsmethoden wieder abmelden
    public void Abkoppeln() => throw new NotImplementedException();

    // TODO: Einschaltungen erhöhen
    private void BeiEin(object? sender, EventArgs e) => throw new NotImplementedException();

    // TODO: Ausschaltungen erhöhen
    private void BeiAus(object? sender, EventArgs e) => throw new NotImplementedException();
}

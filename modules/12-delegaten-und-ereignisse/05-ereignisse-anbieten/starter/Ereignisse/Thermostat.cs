// TODO 1: von EventArgs ableiten; Konstruktor schreiben, der Alt und Neu setzt
public class TemperaturGeaendertEventArgs
{
    public double Alt { get; }
    public double Neu { get; }

    public TemperaturGeaendertEventArgs(double alt, double neu) => throw new NotImplementedException();
}

public class Thermostat
{
    private double _temperatur = 20;

    public double Grenze { get; set; } = 100;

    // TODO 2: Aus den öffentlichen Delegatenfeldern echte Ereignisse (event) machen
    public EventHandler<TemperaturGeaendertEventArgs>? TemperaturGeaendert;
    public EventHandler? Ueberhitzt;

    // TODO 4: Nur bei echter Änderung: Wert setzen, OnTemperaturGeaendert(alt, neu) aufrufen,
    // danach OnUeberhitzt, falls der neue Wert größer als Grenze ist.
    public double Temperatur
    {
        get => _temperatur;
        set => throw new NotImplementedException();
    }

    // TODO 3: Ereignis mit ?.Invoke(this, e) auslösen
    protected virtual void OnTemperaturGeaendert(TemperaturGeaendertEventArgs e) => throw new NotImplementedException();

    // TODO 3: Ereignis mit ?.Invoke(this, e) auslösen
    protected virtual void OnUeberhitzt(EventArgs e) => throw new NotImplementedException();
}

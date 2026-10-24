public class TemperaturGeaendertEventArgs : EventArgs
{
    public double Alt { get; }
    public double Neu { get; }

    public TemperaturGeaendertEventArgs(double alt, double neu)
    {
        Alt = alt;
        Neu = neu;
    }
}

public class Thermostat
{
    private double _temperatur = 20;

    public double Grenze { get; set; } = 100;

    public event EventHandler<TemperaturGeaendertEventArgs>? TemperaturGeaendert;
    public event EventHandler? Ueberhitzt;

    public double Temperatur
    {
        get => _temperatur;
        set
        {
            if (value == _temperatur) return;
            double alt = _temperatur;
            _temperatur = value;
            OnTemperaturGeaendert(new TemperaturGeaendertEventArgs(alt, value));
            if (value > Grenze)
                OnUeberhitzt(EventArgs.Empty);
        }
    }

    protected virtual void OnTemperaturGeaendert(TemperaturGeaendertEventArgs e) =>
        TemperaturGeaendert?.Invoke(this, e);

    protected virtual void OnUeberhitzt(EventArgs e) =>
        Ueberhitzt?.Invoke(this, e);
}

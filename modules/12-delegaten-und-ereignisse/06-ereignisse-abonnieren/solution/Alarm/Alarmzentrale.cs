public class Alarmzentrale
{
    private readonly Dictionary<string, int> _anzahl = new();
    private readonly Dictionary<Sensor, EventHandler<AlarmEventArgs>> _hohe = new();

    public int? HoechsterWert { get; private set; }

    public int HoheAlarme { get; private set; }

    public void Ueberwache(Sensor sensor) => sensor.Alarm += BeiAlarm;

    public void Entferne(Sensor sensor) => sensor.Alarm -= BeiAlarm;

    public void BeiAlarm(object? sender, AlarmEventArgs e)
    {
        if (sender is not Sensor sensor) return;

        _anzahl[sensor.Name] = _anzahl.GetValueOrDefault(sensor.Name) + 1;
        if (HoechsterWert is null || e.Wert > HoechsterWert)
            HoechsterWert = e.Wert;
    }

    public int Anzahl(string name) => _anzahl.GetValueOrDefault(name);

    public void UeberwacheHohe(Sensor sensor, int schwelle)
    {
        EventHandler<AlarmEventArgs> handler = (s, e) =>
        {
            if (e.Wert >= schwelle) HoheAlarme++;
        };
        _hohe[sensor] = handler;   // aufbewahren, damit wir genau dieses Objekt wieder abmelden können
        sensor.Alarm += handler;
    }

    public void EntferneHohe(Sensor sensor)
    {
        if (_hohe.Remove(sensor, out var handler))
            sensor.Alarm -= handler;
    }
}

public class Alarmzentrale
{
    private readonly Dictionary<string, int> _anzahl = new();
    private readonly Dictionary<Sensor, EventHandler<AlarmEventArgs>> _hohe = new();

    public int? HoechsterWert { get; private set; }

    public int HoheAlarme { get; private set; }

    // TODO: BeiAlarm am Ereignis Alarm des Sensors anmelden (+=)
    public void Ueberwache(Sensor sensor) => throw new NotImplementedException();

    // TODO: BeiAlarm wieder abmelden (-=)
    public void Entferne(Sensor sensor) => throw new NotImplementedException();

    // TODO: sender auswerten (is Sensor), Alarme je Sensor.Name zählen, HoechsterWert pflegen
    public void BeiAlarm(object? sender, AlarmEventArgs e) => throw new NotImplementedException();

    // TODO: Anzahl der Alarme dieses Sensornamens; unbekannt: 0
    public int Anzahl(string name) => throw new NotImplementedException();

    // TODO: Lambda erzeugen, das Werte >= schwelle in HoheAlarme zählt, in _hohe[sensor] aufbewahren und anmelden
    public void UeberwacheHohe(Sensor sensor, int schwelle) => throw new NotImplementedException();

    // TODO: das aufbewahrte Lambda aus _hohe holen und abmelden
    public void EntferneHohe(Sensor sensor) => throw new NotImplementedException();
}

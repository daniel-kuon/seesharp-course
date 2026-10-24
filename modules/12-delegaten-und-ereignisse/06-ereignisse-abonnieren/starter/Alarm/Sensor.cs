public class AlarmEventArgs : EventArgs
{
    public int Wert { get; }

    public AlarmEventArgs(int wert) => Wert = wert;
}

public class Sensor
{
    public string Name { get; }

    public event EventHandler<AlarmEventArgs>? Alarm;

    public Sensor(string name) => Name = name;

    public void Ausloesen(int wert) => Alarm?.Invoke(this, new AlarmEventArgs(wert));
}

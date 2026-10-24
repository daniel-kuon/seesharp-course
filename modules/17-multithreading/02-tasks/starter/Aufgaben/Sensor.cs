// Vorgegeben: ein Sensor, der Messwerte per Ereignis meldet.
public class Sensor
{
    public event Action<double>? Messwert;

    // Meldet einen Messwert an alle Abonnenten.
    public void Melde(double wert) => Messwert?.Invoke(wert);

    // Anzahl der Abonnenten des Ereignisses (zum Prüfen, ob sich jemand wieder abgemeldet hat).
    public int Abonnenten => Messwert?.GetInvocationList().Length ?? 0;
}

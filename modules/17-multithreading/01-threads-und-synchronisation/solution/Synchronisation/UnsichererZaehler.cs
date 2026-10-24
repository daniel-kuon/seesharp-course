// Vorgegeben und absichtlich FALSCH: Eine Race Condition.
// "_wert++" besteht aus drei Schritten (lesen, addieren, schreiben). Zwei Threads können
// denselben alten Wert lesen und beide den gleichen neuen zurückschreiben: Ein Update geht verloren.
// Das Ergebnis hängt vom Zufall der Thread-Umschaltung ab; die Tests prüfen diese Klasse nicht.
public class UnsichererZaehler : IZaehler
{
    int _wert;

    public void Erhoehe() => _wert++;

    public int Wert => _wert;
}

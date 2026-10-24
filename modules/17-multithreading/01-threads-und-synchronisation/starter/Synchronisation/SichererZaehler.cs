public class SichererZaehler : IZaehler
{
    // TODO: Ein privates Sperrobjekt (readonly object) und das Feld für den Wert anlegen.

    // TODO: Den Wert innerhalb einer lock-Anweisung um 1 erhöhen.
    public void Erhoehe()
    {
        throw new NotImplementedException();
    }

    // TODO: Auch das Lesen gehört unter dasselbe lock, damit der Leser den neuesten Wert sieht.
    public int Wert => throw new NotImplementedException();
}

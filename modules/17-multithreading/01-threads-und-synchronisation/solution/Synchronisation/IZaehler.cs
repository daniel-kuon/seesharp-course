public interface IZaehler
{
    // Erhöht den Zähler um 1. Darf von mehreren Threads gleichzeitig aufgerufen werden.
    void Erhoehe();

    int Wert { get; }
}

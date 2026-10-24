// Vorgegeben, nicht ändern. Ein unveränderlicher Bruch.
public class Bruch
{
    public int Zaehler { get; }
    public int Nenner { get; }

    // Ein Nenner 0 ist nicht erlaubt: ArgumentException.
    public Bruch(int zaehler, int nenner)
    {
        if (nenner == 0)
            throw new ArgumentException("Der Nenner darf nicht 0 sein.", nameof(nenner));
        Zaehler = zaehler;
        Nenner = nenner;
    }

    public override string ToString() => $"{Zaehler}/{Nenner}";
}

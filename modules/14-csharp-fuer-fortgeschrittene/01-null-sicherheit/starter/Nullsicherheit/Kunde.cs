namespace Nullsicherheit;

public class Kunde
{
    // TODO: Name ist immer gesetzt (im Konstruktor), Spitzname darf fehlen (null).
    public string Name { get; }
    public string Spitzname { get; set; }

    public Kunde(string name)
    {
        // TODO: Name setzen.
    }

    // TODO: "Name (Spitzname)" oder nur "Name", wenn es keinen Spitznamen gibt.
    public string Anzeige()
    {
        return Name + " (" + Spitzname + ")";
    }
}

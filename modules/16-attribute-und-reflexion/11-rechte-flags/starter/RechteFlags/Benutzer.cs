public class Benutzer
{
    // Alle Rollen des Benutzers als ein Bitfeld. Ein neuer Benutzer hat Rolle.Keine.
    public Rolle Rollen { get; private set; }

    // true, wenn der Benutzer ALLE Rollen aus benoetigt hat (Rolle.Keine ist immer erfüllt).
    public bool Darf(Rolle benoetigt)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Fügt die Rollen hinzu (Bits setzen), bereits vorhandene bleiben.
    public void Vergib(Rolle rolle)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Nimmt die Rollen weg (Bits löschen), alle anderen bleiben.
    public void Entziehe(Rolle rolle)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Rollen als Text, z. B. "Leser, Autor" oder "Keine".
    public string Beschreibung()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Liest einen Text wie "Leser, Autor" zurück (Groß-/Kleinschreibung egal).
    // Ein unbekannter Name wirft ArgumentException (Enum.Parse).
    public static Rolle Parse(string text)
    {
        // TODO
        throw new NotImplementedException();
    }
}

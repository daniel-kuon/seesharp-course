using System.Collections.Immutable;

public class Kurs
{
    readonly List<string> teilnehmer = new();

    // Vorgegeben.
    public void Anmelden(string name)
    {
        teilnehmer.Add(name);
    }

    // Eine schreibgeschützte SICHT auf die Teilnehmer: Der Empfänger kann nichts ändern,
    // sieht aber spätere Anmeldungen. Gib nicht die List<string> selbst zurück, sonst
    // könnte der Aufrufer sie zurückcasten und verändern. Tipp: AsReadOnly()
    public IReadOnlyList<string> Teilnehmer
    {
        get
        {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Eine unveränderliche KOPIE zum Zeitpunkt des Aufrufs: Spätere Anmeldungen
    // sieht sie nicht. Tipp: ToImmutableList()
    public ImmutableList<string> Schnappschuss()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Add() einer ImmutableList ändert die Liste nicht, sondern liefert eine NEUE.
    public static ImmutableList<string> MitTeilnehmer(ImmutableList<string> liste, string name)
    {
        // TODO
        throw new NotImplementedException();
    }
}

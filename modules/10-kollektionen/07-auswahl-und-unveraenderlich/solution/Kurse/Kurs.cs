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
    // sieht aber spätere Anmeldungen. Zurückgegeben wird nicht die List<string> selbst.
    public IReadOnlyList<string> Teilnehmer => teilnehmer.AsReadOnly();

    // Eine unveränderliche KOPIE zum Zeitpunkt des Aufrufs: Spätere Anmeldungen sieht sie nicht.
    public ImmutableList<string> Schnappschuss()
    {
        return teilnehmer.ToImmutableList();
    }

    // Add() einer ImmutableList ändert die Liste nicht, sondern liefert eine NEUE.
    public static ImmutableList<string> MitTeilnehmer(ImmutableList<string> liste, string name)
    {
        return liste.Add(name);
    }
}

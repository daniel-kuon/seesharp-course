public record Pruefung(string Fach, string Student, double Note);

public class Notenstatistik(IEnumerable<Pruefung> pruefungen)
{
    private readonly List<Pruefung> _pruefungen = pruefungen.ToList();

    // TODO: Where (Fach), Average der Noten; keine Prüfung im Fach: null
    public double? Durchschnitt(string fach) => throw new NotImplementedException();

    // TODO: OrderBy(Note), ThenBy(Student), ThenBy(Fach) mit StringComparer.Ordinal, Take(n)
    public List<Pruefung> Bestenliste(int n) => throw new NotImplementedException();

    // TODO: GroupBy(Fach), Average je Gruppe, nach Fach sortieren
    public List<(string Fach, double Durchschnitt)> DurchschnittProFach() => throw new NotImplementedException();

    // TODO: Where (Note > 4.0)
    public List<Pruefung> Durchgefallene() => throw new NotImplementedException();
}

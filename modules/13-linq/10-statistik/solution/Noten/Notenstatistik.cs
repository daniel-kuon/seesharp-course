public record Pruefung(string Fach, string Student, double Note);

public class Notenstatistik(IEnumerable<Pruefung> pruefungen)
{
    private readonly List<Pruefung> _pruefungen = pruefungen.ToList();

    public double? Durchschnitt(string fach)
    {
        var noten = _pruefungen.Where(p => p.Fach == fach).Select(p => p.Note).ToList();
        return noten.Count == 0 ? null : noten.Average();
    }

    public List<Pruefung> Bestenliste(int n) =>
        _pruefungen
            .OrderBy(p => p.Note)
            .ThenBy(p => p.Student, StringComparer.Ordinal)
            .ThenBy(p => p.Fach, StringComparer.Ordinal)
            .Take(n)
            .ToList();

    public List<(string Fach, double Durchschnitt)> DurchschnittProFach() =>
        _pruefungen
            .GroupBy(p => p.Fach)
            .Select(g => (Fach: g.Key, Durchschnitt: g.Average(p => p.Note)))
            .OrderBy(x => x.Fach, StringComparer.Ordinal)
            .ToList();

    public List<Pruefung> Durchgefallene() =>
        _pruefungen.Where(p => p.Note > 4.0).ToList();
}

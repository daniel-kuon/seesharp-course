namespace Nulloperatoren;

public static class Auskunft
{
    /// <summary>Ort des Kunden in Großbuchstaben, "unbekannt" wenn irgendwo in der Kette null steht.</summary>
    public static string Ortsname(Kunde? k) => k?.Adresse?.Ort?.ToUpper() ?? "unbekannt";

    public static int Laenge(string[]? a) => a?.Length ?? 0;

    /// <summary>Erstes Element oder null, wenn die Liste selbst null ist. Eine leere Liste wirft.</summary>
    public static string? Erstes(List<string>? l) => l?[0];

    public static string Nachschlagen(Dictionary<string, string>? d, string schluessel) =>
        (d?.TryGetValue(schluessel, out var wert) == true ? wert : null) ?? "(kein Eintrag)";

    /// <summary>Setzt das Alter, falls es einen Kunden gibt. Liefert, ob etwas passiert ist.</summary>
    public static bool SetzeAlter(Kunde? k, int alter)
    {
        k?.Alter = alter;
        return k is not null;
    }

    /// <summary>Wie SetzeAlter, aber der Wert wird nur berechnet, wenn es einen Kunden gibt.</summary>
    public static bool SetzeAlterBerechnet(Kunde? k, Func<int> berechne)
    {
        k?.Alter = berechne();
        return k is not null;
    }

    public static bool Erhoehe(Kunde? k, int differenz)
    {
        k?.Alter += differenz;
        return k is not null;
    }
}

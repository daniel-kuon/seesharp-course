namespace Nulloperatoren;

public static class Auskunft
{
    // TODO: Ort des Kunden in Großbuchstaben (ToUpper); "unbekannt", wenn irgendwo
    //       in der Kette Kunde -> Adresse -> Ort null ist. Eine Zeile mit ?. und ??.
    public static string Ortsname(Kunde? k)
    {
        throw new NotImplementedException();
    }

    // TODO: Länge des Arrays, 0 für null.
    public static int Laenge(string[]? a)
    {
        throw new NotImplementedException();
    }

    // TODO: Erstes Element; null, wenn die Liste selbst null ist (?[ ]).
    //       Bei einer leeren Liste darf die übliche Ausnahme fliegen.
    public static string? Erstes(List<string>? l)
    {
        throw new NotImplementedException();
    }

    // TODO: Wert zum Schlüssel, "(kein Eintrag)" wenn es das Wörterbuch nicht gibt
    //       oder der Schlüssel fehlt. Hinweis: d?.TryGetValue(schluessel, out var wert) == true
    public static string Nachschlagen(Dictionary<string, string>? d, string schluessel)
    {
        throw new NotImplementedException();
    }

    // TODO: Alter setzen mit der null-bedingten Zuweisung k?.Alter = alter (C# 14).
    //       Rückgabe: true, wenn es einen Kunden gab.
    public static bool SetzeAlter(Kunde? k, int alter)
    {
        throw new NotImplementedException();
    }

    // TODO: Wie SetzeAlter, aber berechne() darf nur aufgerufen werden, wenn k nicht null ist.
    public static bool SetzeAlterBerechnet(Kunde? k, Func<int> berechne)
    {
        throw new NotImplementedException();
    }

    // TODO: Alter um differenz erhöhen mit k?.Alter += differenz.
    public static bool Erhoehe(Kunde? k, int differenz)
    {
        throw new NotImplementedException();
    }
}

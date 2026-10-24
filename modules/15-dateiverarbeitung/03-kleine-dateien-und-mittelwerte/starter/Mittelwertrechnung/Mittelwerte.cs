using System.Globalization;

namespace Mittelwertrechnung;

public static class Mittelwerte
{
    // TODO: Berechne die Mittelwerte aller Spalten einer Datei mit ;-getrennten Zahlen
    //       (Buch 16.7, Aufgabe 1). Lies mit File.ReadAllLines, zerlege jede Zeile mit Split(';').
    //       Leere Zeilen überspringen. Spalten zählen ab der längsten Zeile; fehlende Felder in
    //       kürzeren Zeilen werden einfach nicht gezählt.
    //       Ein Feld, das keine Zahl ist, erzeugt die Warnung
    //           "Zeile 3, Spalte 2: 'x' ist keine Zahl"   (Zeilen- und Spaltennummer ab 1,
    //                                                       Zeilennummer = Zeile in der Datei)
    //       und wird bei der Mittelwertbildung übergangen (Rechnen mit den verfügbaren Werten).
    //       Eine Spalte ganz ohne gültigen Wert hat den Mittelwert double.NaN.
    //
    //       Falle: Zahlen stehen immer mit Punkt als Dezimaltrennzeichen in der Datei, egal
    //       welche Spracheinstellung der Rechner hat. Parse deshalb mit
    //       double.TryParse(feld, NumberStyles.Float, CultureInfo.InvariantCulture, out wert).
    //       Ohne NumberStyles.Float würde "4,5" als Tausendertrennung gelten und 45 ergeben.
    public static (double[] mittel, List<string> warnungen) Berechne(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Lies die Quelldatei mit File.ReadAllLines, wandle jede Zeile in Großbuchstaben
    //       (ToUpperInvariant) und schreibe sie mit File.WriteAllLines in die Zieldatei.
    public static void Kopiere(string quelle, string ziel)
    {
        throw new NotImplementedException();
    }

    // TODO: Größe der Datei in Bytes, bestimmt mit File.ReadAllBytes.
    public static int Bytes(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Hänge den Text an das Dateiende an: File.AppendAllText.
    public static void Anhaengen(string pfad, string text)
    {
        throw new NotImplementedException();
    }
}

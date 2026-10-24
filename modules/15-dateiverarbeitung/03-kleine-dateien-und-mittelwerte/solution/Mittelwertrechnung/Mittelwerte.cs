using System.Globalization;

namespace Mittelwertrechnung;

public static class Mittelwerte
{
    /// <summary>
    /// Mittelwerte aller Spalten einer ;-getrennten Zahlendatei. Ungültige Felder erzeugen eine Warnung
    /// und werden übergangen. Eine Spalte ohne gültigen Wert hat den Mittelwert NaN.
    /// </summary>
    public static (double[] mittel, List<string> warnungen) Berechne(string pfad)
    {
        var warnungen = new List<string>();
        var summen = new List<double>();
        var anzahlen = new List<int>();

        string[] zeilen = File.ReadAllLines(pfad);
        for (int z = 0; z < zeilen.Length; z++)
        {
            if (string.IsNullOrWhiteSpace(zeilen[z]))
                continue;

            string[] felder = zeilen[z].Split(';');
            for (int s = 0; s < felder.Length; s++)
            {
                while (summen.Count <= s)
                {
                    summen.Add(0);
                    anzahlen.Add(0);
                }

                string feld = felder[s].Trim();
                if (double.TryParse(feld, NumberStyles.Float, CultureInfo.InvariantCulture, out double wert))
                {
                    summen[s] += wert;
                    anzahlen[s]++;
                }
                else
                {
                    warnungen.Add($"Zeile {z + 1}, Spalte {s + 1}: '{feld}' ist keine Zahl");
                }
            }
        }

        var mittel = new double[summen.Count];
        for (int s = 0; s < mittel.Length; s++)
            mittel[s] = anzahlen[s] == 0 ? double.NaN : summen[s] / anzahlen[s];
        return (mittel, warnungen);
    }

    /// <summary>Schreibt den Inhalt der Quelldatei zeilenweise in Großbuchstaben in die Zieldatei.</summary>
    public static void Kopiere(string quelle, string ziel)
    {
        string[] zeilen = File.ReadAllLines(quelle);
        for (int i = 0; i < zeilen.Length; i++)
            zeilen[i] = zeilen[i].ToUpperInvariant();
        File.WriteAllLines(ziel, zeilen);
    }

    /// <summary>Größe der Datei in Bytes, gelesen mit ReadAllBytes.</summary>
    public static int Bytes(string pfad) => File.ReadAllBytes(pfad).Length;

    /// <summary>Hängt Text an das Dateiende an.</summary>
    public static void Anhaengen(string pfad, string text) => File.AppendAllText(pfad, text);
}

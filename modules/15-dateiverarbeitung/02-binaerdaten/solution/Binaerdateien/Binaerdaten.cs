namespace Binaerdateien;

public static class Binaerdaten
{
    /// <summary>Kopiert byteweise über einen 4096-Byte-Puffer; liefert die Zahl der kopierten Bytes.</summary>
    public static long Kopiere(string quelle, string ziel)
    {
        var ein = new FileStream(quelle, FileMode.Open, FileAccess.Read, FileShare.Read);
        try
        {
            var aus = new FileStream(ziel, FileMode.Create, FileAccess.Write);
            try
            {
                var puffer = new byte[4096];
                long summe = 0;
                int gelesen;
                while ((gelesen = ein.Read(puffer, 0, puffer.Length)) > 0)
                {
                    aus.Write(puffer, 0, gelesen);
                    summe += gelesen;
                }
                return summe;
            }
            finally
            {
                aus.Close();
            }
        }
        finally
        {
            ein.Close();
        }
    }

    /// <summary>Schreibt zuerst die Anzahl (int), dann jeden Wert als double.</summary>
    public static void SchreibeMesswerte(string pfad, double[] werte)
    {
        var datei = new FileStream(pfad, FileMode.Create, FileAccess.Write);
        try
        {
            var schreiber = new BinaryWriter(datei);
            schreiber.Write(werte.Length);
            foreach (var w in werte)
                schreiber.Write(w);
            schreiber.Flush();
        }
        finally
        {
            datei.Close();
        }
    }

    public static double[] LiesMesswerte(string pfad)
    {
        var datei = new FileStream(pfad, FileMode.Open, FileAccess.Read);
        try
        {
            var leser = new BinaryReader(datei);
            int anzahl = leser.ReadInt32();
            var werte = new double[anzahl];
            for (int i = 0; i < anzahl; i++)
                werte[i] = leser.ReadDouble();
            return werte;
        }
        finally
        {
            datei.Close();
        }
    }

    /// <summary>Hängt Bytes ans Dateiende an (FileMode.Append; die Datei wird bei Bedarf angelegt).</summary>
    public static void HaengeAn(string pfad, byte[] daten)
    {
        var datei = new FileStream(pfad, FileMode.Append);
        try
        {
            datei.Write(daten, 0, daten.Length);
        }
        finally
        {
            datei.Close();
        }
    }

    /// <summary>Liest bis zu anzahl Bytes ab der Position offset; am Dateiende kommen weniger (oder keine) zurück.</summary>
    public static byte[] LiesAb(string pfad, long offset, int anzahl)
    {
        var datei = new FileStream(pfad, FileMode.Open, FileAccess.Read);
        try
        {
            datei.Seek(offset, SeekOrigin.Begin);
            var puffer = new byte[anzahl];
            int gesamt = 0;
            int gelesen;
            while (gesamt < anzahl && (gelesen = datei.Read(puffer, gesamt, anzahl - gesamt)) > 0)
                gesamt += gelesen;
            return puffer[..gesamt];
        }
        finally
        {
            datei.Close();
        }
    }

    /// <summary>Legt eine neue, leere Datei an. Gibt es sie schon, passiert nichts und false kommt zurück.</summary>
    public static bool Erzeuge(string pfad)
    {
        if (File.Exists(pfad))
            return false;
        var datei = new FileStream(pfad, FileMode.CreateNew);
        datei.Close();
        return true;
    }
}

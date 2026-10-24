using System.Text;

namespace Ressourcenfreigabe;

// Diese Methoden funktionieren im Normalfall. Aber sie vergessen, Ströme freizugeben, sobald etwas schiefgeht
// (oder immer): Close() steht nur am Ende des Normalwegs oder fehlt ganz.
// TODO: Schreibe jede Methode so um, dass die Freigabe garantiert ist, mit der using-Anweisung bzw.
//       using-Deklaration. Genau EIN Dispose pro Strom, auch wenn eine Ausnahme durchläuft.
public static class Freigabe
{
    // TODO: using-Anweisung um den Strom.
    public static void SchreibeText(Func<Stream> ziel, string text)
    {
        var s = ziel();
        var bytes = Encoding.UTF8.GetBytes(text);
        s.Write(bytes, 0, bytes.Length);
        s.Close();
    }

    // TODO: Zwei geschachtelte using-Anweisungen. Der später geöffnete Strom (Ziel) wird zuerst
    //       freigegeben. Wirft ziel(), muss die Quelle trotzdem freigegeben werden.
    public static void Kopiere(Func<Stream> quelle, Func<Stream> ziel)
    {
        var q = quelle();
        var z = ziel();
        q.CopyTo(z);
        q.Close();
        z.Close();
    }

    // TODO: using-Deklaration (using var s = quelle();): Der Strom wird am Ende der Methode
    //       freigegeben, auch beim return und bei einer Ausnahme.
    public static int ZaehleBytes(Func<Stream> quelle)
    {
        var s = quelle();
        int anzahl = 0;
        while (s.ReadByte() != -1)
            anzahl++;
        return anzahl;
    }

    // TODO: using-Anweisung: Der Strom wird auch freigegeben, wenn die Aktion wirft.
    public static void Verarbeite(Func<Stream> quelle, Action<Stream> aktion)
    {
        var s = quelle();
        aktion(s);
        s.Close();
    }

    // TODO: using-Deklaration INNERHALB von try, catch (IOException) liefert false.
    //       Bei jeder Ausnahme ist die Datei trotzdem geschlossen. Andere Ausnahmetypen
    //       dürfen weiterfliegen.
    public static bool SchreibeSicher(string pfad, IEnumerable<string> zeilen)
    {
        try
        {
            var schreiber = new StreamWriter(pfad);
            foreach (var zeile in zeilen)
                schreiber.WriteLine(zeile);
            schreiber.Close();
            return true;
        }
        catch (IOException)
        {
            return false;
        }
    }
}

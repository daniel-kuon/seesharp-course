// Texteditor mit Rückgängig und Wiederholen: zwei Stapel mit früheren Zuständen.
public class Texteditor
{
    readonly Stack<string> rueckgaengig = new();
    readonly Stack<string> wiederholen = new();

    // Der aktuelle Text.
    public string Text { get; private set; } = "";

    // Hängt zusatz an den Text. Der alte Text kommt auf den Rückgängig-Stapel;
    // danach gibt es nichts mehr zu wiederholen (Wiederholen-Stapel leeren).
    public void Tippe(string zusatz)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Nimmt die letzte Änderung zurück. false, wenn es nichts zurückzunehmen gibt.
    // Der Text vor dem Zurücknehmen wandert auf den Wiederholen-Stapel.
    public bool Rueckgaengig()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Stellt die zuletzt zurückgenommene Änderung wieder her. false, wenn es nichts gibt.
    public bool Wiederholen()
    {
        // TODO
        throw new NotImplementedException();
    }
}

// Druckaufträge werden strikt in Ankunftsreihenfolge gedruckt, Seite für Seite.
public class Druckwarteschlange
{
    readonly Queue<string> seiten = new();

    // Anzahl der noch zu druckenden Seiten.
    public int Wartend
    {
        get
        {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Reiht einen Auftrag mit der angegebenen Seitenzahl ein. Die Seiten heißen
    // "<name> 1/3", "<name> 2/3", ... Bei seiten < 1 wird nichts eingereiht.
    // Achtung: Der Parameter seiten verdeckt das Feld; schreibe this.seiten.
    public void Auftrag(string name, int seiten)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die nächste zu druckende Seite oder null, wenn nichts wartet.
    public string? NaechsteSeite()
    {
        // TODO
        throw new NotImplementedException();
    }
}

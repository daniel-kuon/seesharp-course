// Texteditor mit Rückgängig und Wiederholen: zwei Stapel mit früheren Zuständen.
public class Texteditor
{
    readonly Stack<string> rueckgaengig = new();
    readonly Stack<string> wiederholen = new();

    // Der aktuelle Text.
    public string Text { get; private set; } = "";

    // Hängt zusatz an den Text. Danach gibt es nichts mehr zu wiederholen.
    public void Tippe(string zusatz)
    {
        rueckgaengig.Push(Text);
        Text += zusatz;
        wiederholen.Clear();
    }

    // Nimmt die letzte Änderung zurück. false, wenn es nichts zurückzunehmen gibt.
    public bool Rueckgaengig()
    {
        if (rueckgaengig.Count == 0)
            return false;
        wiederholen.Push(Text);
        Text = rueckgaengig.Pop();
        return true;
    }

    // Stellt die zuletzt zurückgenommene Änderung wieder her. false, wenn es nichts gibt.
    public bool Wiederholen()
    {
        if (wiederholen.Count == 0)
            return false;
        rueckgaengig.Push(Text);
        Text = wiederholen.Pop();
        return true;
    }
}

// Druckaufträge werden strikt in Ankunftsreihenfolge gedruckt, Seite für Seite.
public class Druckwarteschlange
{
    readonly Queue<string> seiten = new();

    // Anzahl der noch zu druckenden Seiten.
    public int Wartend => seiten.Count;

    // Reiht einen Auftrag mit der angegebenen Seitenzahl ein.
    // Die Seiten heißen "<name> 1/3", "<name> 2/3", ... Bei seiten < 1 wird nichts eingereiht.
    public void Auftrag(string name, int seiten)
    {
        for (int i = 1; i <= seiten; i++)
            this.seiten.Enqueue($"{name} {i}/{seiten}");
    }

    // Die nächste zu druckende Seite oder null, wenn nichts wartet.
    public string? NaechsteSeite()
    {
        return seiten.Count > 0 ? seiten.Dequeue() : null;
    }
}

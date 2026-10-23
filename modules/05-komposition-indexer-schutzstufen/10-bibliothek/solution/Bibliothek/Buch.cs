public class Buch(string titel, string autor, int jahr) {
    public string Titel { get; } = titel;
    public string Autor { get; } = autor;
    public int Jahr { get; } = jahr;
    public bool Ausgeliehen { get; set; }

    // Liefert z. B. "Der Process (Kafka, 1925)".
    public override string ToString() {
        return $"{Titel} ({Autor}, {Jahr})";
    }
}

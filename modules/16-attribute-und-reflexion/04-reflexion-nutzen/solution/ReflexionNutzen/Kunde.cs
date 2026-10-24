public class Kunde
{
    [Spalte("name")]
    public string Name { get; set; } = "";

    // Keine Spalte: wird nicht gespeichert.
    public string Notiz { get; set; } = "";

    [Spalte("alter")]
    public int Alter { get; set; }

    [Spalte("rabatt")]
    public double Rabatt { get; set; }

    [Spalte("aktiv")]
    public bool Aktiv { get; set; }
}

// Ein Beispiel wie im Buch (14.9 Aufgabe 1): eine Klasse mit mehreren Attributen.
[Obsolete("Nicht mehr verwenden")]
[Autor("Anna")]
[Autor("Ben")]
public class Dummy
{
    [Autor("Anna")]
    public void Tue() { }

    public int Alter { get; set; }
}

// Fertig: eine Aufgabe mit Titel und Erledigt-Markierung, die Änderungen meldet.
public class Aufgabe : ViewModelBase
{
    private bool _erledigt;

    public Aufgabe(string titel) => Titel = titel;

    public string Titel { get; }

    public bool Erledigt
    {
        get => _erledigt;
        set => SetProperty(ref _erledigt, value);
    }
}

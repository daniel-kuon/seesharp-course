using System.Collections.ObjectModel;

// ViewModelBase und RelayCommand liegen fertig bei (oder nimm deine eigenen).
public class NotizenViewModel : ViewModelBase
{
    private string _text = "";
    private string? _ausgewaehlt;

    // TODO 1: Befehle erzeugen:
    //  - Hinzufuegen: ruft FuegeHinzu() auf; ausführbar nur, wenn Text nicht leer und nicht nur Leerraum ist
    //  - Loeschen: ruft LoescheAusgewaehlte() auf; ausführbar nur, wenn Ausgewaehlt nicht null ist
    public NotizenViewModel()
        => throw new NotImplementedException();

    public ObservableCollection<string> Notizen { get; } = new();

    // TODO 2: Setter mit SetProperty; bei Änderung Hinzufuegen.RaiseCanExecuteChanged().
    public string Text
    {
        get => _text;
        set => throw new NotImplementedException();
    }

    // TODO 3: Setter mit SetProperty; bei Änderung Loeschen.RaiseCanExecuteChanged().
    // In der Oberfläche ist das die SelectedItem-Eigenschaft der ListBox; null heißt: nichts ausgewählt.
    public string? Ausgewaehlt
    {
        get => _ausgewaehlt;
        set => throw new NotImplementedException();
    }

    public RelayCommand Hinzufuegen { get; }
    public RelayCommand Loeschen { get; }

    // TODO 4: Den getrimmten Text zu Notizen hinzufügen und Text leeren.
    private void FuegeHinzu() => throw new NotImplementedException();

    // TODO 5: Die ausgewählte Notiz aus Notizen entfernen und danach nichts mehr auswählen (null).
    private void LoescheAusgewaehlte() => throw new NotImplementedException();
}

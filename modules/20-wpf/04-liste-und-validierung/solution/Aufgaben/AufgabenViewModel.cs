using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

public class AufgabenViewModel : ViewModelBase, INotifyDataErrorInfo
{
    private string _neuerTitel = "";
    private string? _titelFehler;

    public AufgabenViewModel()
    {
        Aufgaben.CollectionChanged += AufgabenGeaendert;
        HinzufuegenCommand = new RelayCommand(_ => Hinzufuegen(), _ => !HasErrors);
        ErledigteEntfernenCommand = new RelayCommand(_ => ErledigteEntfernen(), _ => Aufgaben.Any(a => a.Erledigt));
        _titelFehler = Pruefe(_neuerTitel); // Startzustand: leerer Titel ist ungültig
    }

    public ObservableCollection<Aufgabe> Aufgaben { get; } = new();

    public string NeuerTitel
    {
        get => _neuerTitel;
        set
        {
            if (!SetProperty(ref _neuerTitel, value))
                return;
            var fehler = Pruefe(value);
            if (fehler == _titelFehler)
                return;
            _titelFehler = fehler;
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(NeuerTitel)));
            OnPropertyChanged(nameof(HasErrors));
            HinzufuegenCommand.RaiseCanExecuteChanged();
        }
    }

    public int OffeneAnzahl => Aufgaben.Count(a => !a.Erledigt);

    public RelayCommand HinzufuegenCommand { get; }
    public RelayCommand ErledigteEntfernenCommand { get; }

    // ----- INotifyDataErrorInfo ------------------------------------------------------------

    public bool HasErrors => _titelFehler is not null;

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (_titelFehler is not null && (string.IsNullOrEmpty(propertyName) || propertyName == nameof(NeuerTitel)))
            return new[] { _titelFehler };
        return Array.Empty<string>();
    }

    private static string? Pruefe(string titel)
    {
        if (string.IsNullOrWhiteSpace(titel))
            return "Titel darf nicht leer sein";
        if (titel.Length > 50)
            return "Titel zu lang";
        return null;
    }

    // ----- Befehle und Sammlung ------------------------------------------------------------

    private void Hinzufuegen()
    {
        Aufgaben.Add(new Aufgabe(NeuerTitel.Trim()));
        NeuerTitel = "";
    }

    private void ErledigteEntfernen()
    {
        foreach (var aufgabe in Aufgaben.Where(a => a.Erledigt).ToList())
            Aufgaben.Remove(aufgabe);
    }

    private void AufgabenGeaendert(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is not null)
            foreach (Aufgabe a in e.OldItems)
                a.PropertyChanged -= AufgabeGeaendert;
        if (e.NewItems is not null)
            foreach (Aufgabe a in e.NewItems)
                a.PropertyChanged += AufgabeGeaendert;
        Aktualisiere();
    }

    private void AufgabeGeaendert(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Aufgabe.Erledigt))
            Aktualisiere();
    }

    private void Aktualisiere()
    {
        OnPropertyChanged(nameof(OffeneAnzahl));
        ErledigteEntfernenCommand.RaiseCanExecuteChanged();
    }
}

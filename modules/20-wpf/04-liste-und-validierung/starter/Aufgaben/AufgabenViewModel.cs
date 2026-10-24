using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

public class AufgabenViewModel : ViewModelBase, INotifyDataErrorInfo
{
    private string _neuerTitel = "";
    private string? _titelFehler; // aktuelle Fehlermeldung zu NeuerTitel oder null

    // TODO 1: Im Konstruktor
    //  - CollectionChanged der Aufgaben abonnieren (TODO 4),
    //  - HinzufuegenCommand erzeugen: ausführbar nur, wenn !HasErrors; ruft Hinzufuegen() auf,
    //  - ErledigteEntfernenCommand erzeugen: ausführbar nur, wenn mindestens eine Aufgabe Erledigt ist;
    //    ruft ErledigteEntfernen() auf,
    //  - den Startzustand prüfen: _titelFehler = Pruefe(_neuerTitel) (ein leerer Titel ist ungültig).
    public AufgabenViewModel()
        => throw new NotImplementedException();

    public ObservableCollection<Aufgabe> Aufgaben { get; } = new();

    // TODO 2: Setter mit SetProperty. Danach neu prüfen (Pruefe). Hat sich die Fehlermeldung geändert:
    //  - _titelFehler speichern,
    //  - ErrorsChanged mit new DataErrorsChangedEventArgs(nameof(NeuerTitel)) genau einmal auslösen,
    //  - PropertyChanged für HasErrors melden,
    //  - HinzufuegenCommand.RaiseCanExecuteChanged() aufrufen.
    // Ändert sich die Meldung nicht (z. B. "a" -> "ab"), passiert nichts.
    public string NeuerTitel
    {
        get => _neuerTitel;
        set => throw new NotImplementedException();
    }

    // TODO 5: berechnete Eigenschaft: Anzahl der Aufgaben, die nicht Erledigt sind.
    public int OffeneAnzahl => throw new NotImplementedException();

    public RelayCommand HinzufuegenCommand { get; }
    public RelayCommand ErledigteEntfernenCommand { get; }

    // ----- INotifyDataErrorInfo ------------------------------------------------------------

    // TODO 3: true, wenn es eine Fehlermeldung gibt.
    public bool HasErrors => throw new NotImplementedException();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    // TODO 3: Die Fehlermeldungen zu einer Eigenschaft. Für "NeuerTitel" sowie für null oder "" (= alle
    // Eigenschaften) die aktuelle Meldung (falls vorhanden) als einelementige Liste; für jeden anderen
    // Namen eine leere Liste.
    public IEnumerable GetErrors(string? propertyName) => throw new NotImplementedException();

    // TODO 3: leer oder nur Leerraum: "Titel darf nicht leer sein"; länger als 50 Zeichen: "Titel zu lang";
    // sonst null.
    private static string? Pruefe(string titel) => throw new NotImplementedException();

    // ----- Befehle und Sammlung ------------------------------------------------------------

    // TODO 6: Eine neue Aufgabe mit dem getrimmten Titel hinzufügen, danach NeuerTitel leeren.
    private void Hinzufuegen() => throw new NotImplementedException();

    // TODO 6: Alle erledigten Aufgaben aus der Sammlung entfernen (nicht beim Durchlaufen der Sammlung
    // selbst entfernen: erst eine Kopie anlegen, z. B. mit ToList()).
    private void ErledigteEntfernen() => throw new NotImplementedException();

    // TODO 4: Handler für CollectionChanged. An neu hinzugekommenen Aufgaben (e.NewItems) PropertyChanged
    // abonnieren, von entfernten (e.OldItems) abmelden, danach Aktualisiere() aufrufen.
    private void AufgabenGeaendert(object? sender, NotifyCollectionChangedEventArgs e)
        => throw new NotImplementedException();

    // TODO 4: Handler für PropertyChanged einer Aufgabe: Nur wenn sich Erledigt geändert hat, Aktualisiere().
    private void AufgabeGeaendert(object? sender, PropertyChangedEventArgs e)
        => throw new NotImplementedException();

    // TODO 4: PropertyChanged für OffeneAnzahl melden und ErledigteEntfernenCommand.RaiseCanExecuteChanged().
    private void Aktualisiere() => throw new NotImplementedException();
}

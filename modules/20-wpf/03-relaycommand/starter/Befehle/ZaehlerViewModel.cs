using System.Globalization;

public class ZaehlerViewModel : ViewModelBase
{
    private int _wert;

    // TODO 5: Die drei Befehle erzeugen:
    //  - Erhoehen: Wert um 1 erhöhen, immer ausführbar
    //  - Verringern: Wert um 1 verringern, nur ausführbar, solange Wert > 0
    //  - SetzeAuf: setzt Wert auf den Parameter; ausführbar nur, wenn LiesZahl(parameter) eine Zahl >= 0 liefert
    public ZaehlerViewModel()
        => throw new NotImplementedException();

    // TODO 6: Setter mit SetProperty; ändert sich der Wert, hat sich auch die Ausführbarkeit von
    // Verringern geändert: Verringern.RaiseCanExecuteChanged() aufrufen.
    public int Wert
    {
        get => _wert;
        private set => throw new NotImplementedException();
    }

    public RelayCommand Erhoehen { get; }
    public RelayCommand Verringern { get; }
    public RelayCommand SetzeAuf { get; }

    // Akzeptiert einen int oder einen String mit einer ganzen Zahl (z. B. aus einem XAML-CommandParameter);
    // sonst null. Diese Hilfsmethode ist fertig.
    private static int? LiesZahl(object? parameter) => parameter switch
    {
        int zahl => zahl,
        string text when int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var zahl) => zahl,
        _ => null,
    };
}

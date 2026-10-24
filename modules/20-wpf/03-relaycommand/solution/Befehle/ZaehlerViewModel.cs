using System.Globalization;

public class ZaehlerViewModel : ViewModelBase
{
    private int _wert;

    public ZaehlerViewModel()
    {
        Erhoehen = new RelayCommand(_ => Wert++);
        Verringern = new RelayCommand(_ => Wert--, _ => Wert > 0);
        SetzeAuf = new RelayCommand(p => Wert = LiesZahl(p)!.Value, p => LiesZahl(p) is >= 0);
    }

    public int Wert
    {
        get => _wert;
        private set
        {
            if (SetProperty(ref _wert, value))
                Verringern.RaiseCanExecuteChanged();
        }
    }

    public RelayCommand Erhoehen { get; }
    public RelayCommand Verringern { get; }
    public RelayCommand SetzeAuf { get; }

    // Akzeptiert einen int oder einen String mit einer ganzen Zahl; sonst null.
    private static int? LiesZahl(object? parameter) => parameter switch
    {
        int zahl => zahl,
        string text when int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var zahl) => zahl,
        _ => null,
    };
}

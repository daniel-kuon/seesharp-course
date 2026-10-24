using System.Globalization;

public class RechnerViewModel : ViewModelBase
{
    private static readonly NumberFormatInfo Deutsch = new() { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };
    private const NumberStyles Stil = NumberStyles.AllowDecimalPoint;
    private const int MaxZeichen = 15;

    private string _eingabe = "";      // Zahl, die gerade getippt wird (leer: keine)
    private decimal? _links;           // bisheriges Ergebnis bzw. erster Operand
    private char? _operator;           // wartender Operator
    private bool _fehler;
    private bool _ergebnisAngezeigt;   // nach "=": die nächste Ziffer beginnt eine neue Rechnung

    public RechnerViewModel()
    {
        ZifferCommand = new RelayCommand(p => Ziffer((string)p!),
            p => p is string { Length: 1 } s && (char.IsAsciiDigit(s[0]) || s[0] == ','));
        OperatorCommand = new RelayCommand(p => Operator(((string)p!)[0]), p => p is "+" or "-" or "*" or "/");
        GleichCommand = new RelayCommand(_ => Gleich());
        LoeschenCommand = new RelayCommand(_ => Loesche());
    }

    public string Anzeige => _fehler ? "Fehler"
        : _eingabe.Length > 0 ? _eingabe
        : _links is { } l ? Format(l)
        : "0";

    public RelayCommand ZifferCommand { get; }
    public RelayCommand OperatorCommand { get; }
    public RelayCommand GleichCommand { get; }
    public RelayCommand LoeschenCommand { get; }

    private void Ziffer(string zeichen)
    {
        if (_fehler)
            return;
        if (_ergebnisAngezeigt)
        {
            _links = null;
            _operator = null;
            _eingabe = "";
            _ergebnisAngezeigt = false;
        }
        if (zeichen == ",")
        {
            if (_eingabe.Contains(',') || _eingabe.Length >= MaxZeichen)
                return;
            _eingabe = _eingabe.Length == 0 ? "0," : _eingabe + ",";
        }
        else
        {
            if (_eingabe.Length >= MaxZeichen)
                return;
            _eingabe = _eingabe == "0" ? zeichen : _eingabe + zeichen;
        }
        OnPropertyChanged(nameof(Anzeige));
    }

    private void Operator(char zeichen)
    {
        if (_fehler)
            return;
        if (_eingabe.Length > 0)
        {
            var zahl = decimal.Parse(_eingabe, Stil, Deutsch);
            if (_links is { } links && _operator is { } op)
            {
                if (!TryBerechne(links, op, zahl, out var ergebnis))
                {
                    ZeigeFehler();
                    return;
                }
                _links = ergebnis;
            }
            else
            {
                _links = zahl;
            }
            _eingabe = "";
        }
        else if (_links is null)
        {
            return;
        }
        _operator = zeichen;
        _ergebnisAngezeigt = false;
        OnPropertyChanged(nameof(Anzeige));
    }

    private void Gleich()
    {
        if (_fehler || _links is not { } links || _operator is not { } op || _eingabe.Length == 0)
            return;
        if (!TryBerechne(links, op, decimal.Parse(_eingabe, Stil, Deutsch), out var ergebnis))
        {
            ZeigeFehler();
            return;
        }
        _links = ergebnis;
        _eingabe = "";
        _operator = null;
        _ergebnisAngezeigt = true;
        OnPropertyChanged(nameof(Anzeige));
    }

    private void Loesche()
    {
        _eingabe = "";
        _links = null;
        _operator = null;
        _fehler = false;
        _ergebnisAngezeigt = false;
        OnPropertyChanged(nameof(Anzeige));
    }

    private void ZeigeFehler()
    {
        _fehler = true;
        OnPropertyChanged(nameof(Anzeige));
    }

    private static bool TryBerechne(decimal links, char op, decimal rechts, out decimal ergebnis)
    {
        ergebnis = 0;
        try
        {
            switch (op)
            {
                case '+': ergebnis = links + rechts; return true;
                case '-': ergebnis = links - rechts; return true;
                case '*': ergebnis = links * rechts; return true;
                case '/':
                    if (rechts == 0)
                        return false;
                    ergebnis = links / rechts;
                    return true;
                default: return false;
            }
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    private static string Format(decimal zahl) => Math.Round(zahl, 8).ToString("0.########", Deutsch);
}

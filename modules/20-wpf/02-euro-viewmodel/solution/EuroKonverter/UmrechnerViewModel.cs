using System.Globalization;

public class UmrechnerViewModel : ViewModelBase
{
    public const decimal Kurs = 1.95583m;

    // Deutsche Schreibweise, unabhängig von der Kultur des Rechners: Komma als Dezimaltrenner.
    private static readonly NumberFormatInfo Deutsch = new() { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };
    private const NumberStyles Stil = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;

    private string _euroText = "";
    private string _dmText = "";
    private string _fehlermeldung = "";

    public string EuroText
    {
        get => _euroText;
        set
        {
            if (!SetProperty(ref _euroText, value))
                return;
            // Partnerfeld über das Feld setzen, nicht über die Eigenschaft: So gibt es kein Ping-Pong.
            Aktualisiere(value, Kurs, ref _dmText, nameof(DmText), "Euro");
        }
    }

    public string DmText
    {
        get => _dmText;
        set
        {
            if (!SetProperty(ref _dmText, value))
                return;
            Aktualisiere(value, 1 / Kurs, ref _euroText, nameof(EuroText), "DM");
        }
    }

    public string Fehlermeldung
    {
        get => _fehlermeldung;
        private set
        {
            if (SetProperty(ref _fehlermeldung, value))
                OnPropertyChanged(nameof(HatFehler));
        }
    }

    public bool HatFehler => Fehlermeldung.Length > 0;

    private void Aktualisiere(string eingabe, decimal faktor, ref string partner, string partnerName, string einheit)
    {
        if (string.IsNullOrWhiteSpace(eingabe))
        {
            Fehlermeldung = "";
            SetProperty(ref partner, "", partnerName);
            return;
        }
        if (!decimal.TryParse(eingabe, Stil, Deutsch, out var zahl))
        {
            Fehlermeldung = $"Kein gültiger {einheit}-Betrag (Dezimaltrenner ist das Komma).";
            return;
        }
        Fehlermeldung = "";
        var ergebnis = Math.Round(zahl * faktor, 2, MidpointRounding.AwayFromZero);
        SetProperty(ref partner, ergebnis.ToString("F2", Deutsch), partnerName);
    }
}

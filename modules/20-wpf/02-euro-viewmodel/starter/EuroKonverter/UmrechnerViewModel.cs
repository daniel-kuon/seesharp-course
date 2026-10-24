using System.Globalization;

public class UmrechnerViewModel : ViewModelBase
{
    public const decimal Kurs = 1.95583m; // 1 Euro = 1,95583 DM

    // Deutsche Schreibweise, unabhängig von der Kultur des Rechners: Komma als Dezimaltrenner.
    // Zum Parsen: decimal.TryParse(text, Stil, Deutsch, out var zahl); zum Formatieren: zahl.ToString("F2", Deutsch)
    private static readonly NumberFormatInfo Deutsch = new() { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };
    private const NumberStyles Stil = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;

    private string _euroText = "";
    private string _dmText = "";
    private string _fehlermeldung = "";

    // TODO 3: Setter: Feld mit SetProperty setzen (gleicher Wert: nichts weiter tun).
    // Danach DmText berechnen (Euro * Kurs, auf 2 Stellen gerundet, "F2") und das FELD _dmText mit
    // SetProperty(ref _dmText, ..., nameof(DmText)) setzen - nicht die Eigenschaft DmText, sonst Ping-Pong.
    // Leere Eingabe: Partner = "" und keine Fehlermeldung.
    // Ungültige Eingabe: Fehlermeldung setzen (immer derselbe Text, z. B. "Kein gültiger Euro-Betrag"),
    // Partner unverändert lassen.
    // Gültige Eingabe: Fehlermeldung = "".
    public string EuroText
    {
        get => _euroText;
        set => throw new NotImplementedException();
    }

    // TODO 4: wie EuroText, nur in die andere Richtung (DM / Kurs, Partner ist EuroText).
    public string DmText
    {
        get => _dmText;
        set => throw new NotImplementedException();
    }

    // TODO 5: Der Setter ist privat. Ändert sich die Meldung, werden Fehlermeldung UND HatFehler gemeldet.
    public string Fehlermeldung
    {
        get => _fehlermeldung;
        private set => throw new NotImplementedException();
    }

    // TODO 6: berechnete Eigenschaft: true, wenn Fehlermeldung nicht leer ist.
    public bool HatFehler => throw new NotImplementedException();
}

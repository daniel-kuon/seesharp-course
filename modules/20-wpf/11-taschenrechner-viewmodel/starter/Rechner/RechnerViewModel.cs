using System.Globalization;

// Ein einfacher Taschenrechner ohne Punkt-vor-Strich-Rechnung: Es wird von links nach rechts gerechnet
// (2 + 3 * 4 = 20). ViewModelBase und RelayCommand liegen fertig bei.
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

    // TODO 1: Die vier Befehle erzeugen.
    //  - ZifferCommand: Parameter ist ein string mit genau einem Zeichen: Ziffer "0".."9" oder ","
    //    (CanExecute prüft das, Execute ruft Ziffer(...) auf)
    //  - OperatorCommand: Parameter "+", "-", "*" oder "/" (CanExecute prüft das, Execute ruft Operator(...) auf)
    //  - GleichCommand und LoeschenCommand: immer ausführbar
    public RechnerViewModel()
        => throw new NotImplementedException();

    // TODO 2: berechnete Eigenschaft ohne eigenes Feld:
    //  - im Fehlerzustand "Fehler"
    //  - sonst die gerade getippte Zahl (_eingabe), falls vorhanden
    //  - sonst das bisherige Ergebnis (_links) über Format(...)
    //  - sonst "0"
    public string Anzeige => throw new NotImplementedException();

    public RelayCommand ZifferCommand { get; }
    public RelayCommand OperatorCommand { get; }
    public RelayCommand GleichCommand { get; }
    public RelayCommand LoeschenCommand { get; }

    // TODO 3: Ziffer oder Komma anhängen.
    //  - Im Fehlerzustand: nichts tun (auch keine Meldung).
    //  - Wurde gerade ein Ergebnis angezeigt (_ergebnisAngezeigt), beginnt eine neue Rechnung:
    //    _links, _operator und _eingabe zurücksetzen.
    //  - Komma: ignorieren (ohne Meldung), wenn die Eingabe schon eins enthält; ist die Eingabe leer, wird
    //    daraus "0,".
    //  - Ziffer: eine führende "0" wird ersetzt ("0" + "5" = "5"). Länger als MaxZeichen wird nichts mehr
    //    angehängt (ohne Meldung).
    //  - Ansonsten genau einmal PropertyChanged für Anzeige melden.
    private void Ziffer(string zeichen) => throw new NotImplementedException();

    // TODO 4: Operator wählen.
    //  - Im Fehlerzustand: nichts tun.
    //  - Gibt es eine getippte Zahl: Ist schon ein Operator mit linkem Operand da, wird zuerst das
    //    Zwischenergebnis berechnet (TryBerechne; bei false: ZeigeFehler() und Ende), sonst wird die Zahl der
    //    linke Operand. _eingabe wird leer.
    //  - Gibt es keine getippte Zahl, aber ein bisheriges Ergebnis (_links): nur den Operator ersetzen.
    //  - Gibt es gar nichts, passiert nichts (ohne Meldung).
    //  - Danach _operator setzen, _ergebnisAngezeigt = false und Anzeige melden.
    private void Operator(char zeichen) => throw new NotImplementedException();

    // TODO 5: "=": Nur wenn kein Fehler vorliegt und linker Operand, Operator und getippte Zahl da sind:
    // berechnen (bei false: ZeigeFehler()), das Ergebnis wird _links, _eingabe leer, _operator weg,
    // _ergebnisAngezeigt = true, Anzeige melden. Sonst passiert nichts (ohne Meldung).
    private void Gleich() => throw new NotImplementedException();

    // TODO 6: "C": alles zurücksetzen (auch den Fehlerzustand) und genau einmal Anzeige melden.
    private void Loesche() => throw new NotImplementedException();

    // TODO 7: Fehlerzustand setzen und Anzeige melden.
    private void ZeigeFehler() => throw new NotImplementedException();

    // TODO 8: Das Ergebnis von links op rechts. Division durch 0 und ein Überlauf (OverflowException)
    // geben false zurück.
    private static bool TryBerechne(decimal links, char op, decimal rechts, out decimal ergebnis)
        => throw new NotImplementedException();

    // Fertig: Ergebnis auf 8 Nachkommastellen runden und mit Komma ausgeben (3,5 statt 3.5).
    private static string Format(decimal zahl) => Math.Round(zahl, 8).ToString("0.########", Deutsch);
}

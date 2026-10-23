// Ein Girokonto mit Dispositionskredit (Dispo).
public class Konto {
    // Die nächste freie Kontonummer; jedes neue Konto bekommt sie und erhöht sie.
    static int naechsteNummer = 1000;

    // Wie viele Konten bisher erzeugt wurden.
    public static int Anzahl { get; private set; }

    // Fortlaufende Kontonummer, wird nur im Konstruktor gesetzt.
    public int Nummer { get; }

    // Der Kontostand kann von außen nur gelesen werden.
    public decimal Kontostand { get; private set; }

    // Inhaber: leere Namen (oder nur Leerzeichen) werden ignoriert.
    public string Inhaber {
        get;
        set {
            if (!string.IsNullOrWhiteSpace(value))
                field = value;
        }
    } = "unbekannt";

    // Dispo: negative Werte werden ignoriert.
    public decimal Dispo {
        get;
        set {
            if (value >= 0)
                field = value;
        }
    }

    public Konto(string inhaber) {
        Nummer = naechsteNummer;
        naechsteNummer++;
        Anzahl++;
        Inhaber = inhaber;
    }

    public Konto(string inhaber, decimal startguthaben) {
        Nummer = naechsteNummer;
        naechsteNummer++;
        Anzahl++;
        Inhaber = inhaber;
        if (startguthaben > 0)
            Kontostand = startguthaben;
    }

    // Zahlt einen positiven Betrag ein; sonst false und keine Änderung.
    public bool Einzahlen(decimal betrag) {
        if (betrag <= 0)
            return false;
        Kontostand += betrag;
        return true;
    }

    // Hebt einen positiven Betrag ab, solange der Kontostand nicht unter -Dispo fällt.
    public bool Abheben(decimal betrag) {
        if (betrag <= 0 || Kontostand - betrag < -Dispo)
            return false;
        Kontostand -= betrag;
        return true;
    }

    // Überweist auf ein anderes Konto: nur wenn das Abheben hier gelingt.
    public bool Ueberweise(Konto ziel, decimal betrag) {
        if (ziel == this || !Abheben(betrag))
            return false;
        ziel.Einzahlen(betrag);
        return true;
    }
}

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
            // TODO: nur übernehmen, wenn value nicht leer ist und nicht nur aus Leerzeichen besteht
            throw new NotImplementedException();
        }
    } = "unbekannt";

    // Dispo: negative Werte werden ignoriert.
    public decimal Dispo {
        get;
        set {
            // TODO: nur Werte >= 0 übernehmen
            throw new NotImplementedException();
        }
    }

    public Konto(string inhaber) {
        // TODO: Nummer vergeben, Anzahl erhöhen, Inhaber über die Eigenschaft setzen
        throw new NotImplementedException();
    }

    public Konto(string inhaber, decimal startguthaben) {
        // TODO: wie oben; ein negatives Startguthaben wird zu 0
        throw new NotImplementedException();
    }

    // Zahlt einen positiven Betrag ein; sonst false und keine Änderung.
    public bool Einzahlen(decimal betrag) {
        // TODO
        throw new NotImplementedException();
    }

    // Hebt einen positiven Betrag ab, solange der Kontostand nicht unter -Dispo fällt.
    public bool Abheben(decimal betrag) {
        // TODO
        throw new NotImplementedException();
    }

    // Überweist auf ein anderes Konto: nur wenn das Abheben hier gelingt.
    public bool Ueberweise(Konto ziel, decimal betrag) {
        // TODO: ziel darf nicht dieses Konto selbst sein
        throw new NotImplementedException();
    }
}

# OOP-Begriffe im Quelltext

Lies im Buch Abschnitt **5.1 Überblick, historische Wurzeln, Beispiel**
(Seite 286) mit 5.1.3 (Auf-Bruch zu echter Klasse, Seite 293). Die Aufgabe
entspricht 5.15 Aufgabe 7 (Seite 428).

Im folgenden Kurzlisting der Klasse `Bruch` sind zwölf Stellen markiert.
Ordne in den Fragen jedem Begriff die richtige Markierung zu.

```csharp
public class Bruch {                                        // (1)
    int zaehler, nenner = 1;                                // (2)
    static int anzahl;                                      // (3)

    public Bruch(int zpar, int npar) {                      // (4)
        Zaehler = zpar; Nenner = npar; anzahl++;
    }

    public int Zaehler {                                    // (5)
        get { return zaehler; }
        set { zaehler = value; }
    }

    public int Nenner {
        get { return nenner; }
        set { if (value != 0) nenner = value; }
    }

    public static int Anzahl {                              // (6)
        get { return anzahl; }
    }

    public void Addiere(Bruch b) {                          // (7)
        Zaehler = zaehler * b.nenner + b.zaehler * nenner;
        Nenner = nenner * b.nenner;
        Kuerze();                                           // (8)
    }

    public Bruch Klone() {                                  // (9)
        return new Bruch(zaehler, nenner);
    }

    public static Bruch Halb() {                            // (10)
        var h = new Bruch(1, 2);                            // (11)
        return h;
    }

    public static Bruch operator +(Bruch b1, Bruch b2) {    // (12)
        var summe = b1.Klone();
        summe.Addiere(b2);
        return summe;
    }

    public void Kuerze() { /* ... */ }
}
```

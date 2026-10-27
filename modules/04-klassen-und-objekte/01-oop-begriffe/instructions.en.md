# OOP Terms in the Source Code

Read Section **5.1, “Overview, Historical Roots, Example”** (page 286), along with 5.1.3, “Toward a True Class” (page 293), in the book. The exercise corresponds to Exercise 7 in Section 5.15 (page 428).

In the following short listing of the `Bruch` class, twelve items are highlighted. For each question, match each term with the correct highlight.

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

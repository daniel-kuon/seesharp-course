# Rubrik — Zusatz: Tiere als Objekte (nur für die Betreuung)

Zusatzaufgabe zu Level 1. Ziel: Klasse (Bauplan) und Objekt (Exemplar mit
`new`) einmal selbst anfassen, bevor Level 4 Klassen richtig einführt.

- Nachfragen: Warum geht `Hund.Laut()` nicht, `new Hund().Laut()` aber schon?
  (Instanzmethode, braucht ein Objekt.) Warum ist `Konzert()` `static`?
- `StellDichVor()` soll `Name()` und `Laut()` aufrufen, nicht den Text noch
  einmal hart hinschreiben. Die Tests merken das nicht; im Review ansehen.
- Ausblick: Beide Klassen haben dieselben Methoden. In Level 7 wird daraus
  eine Basisklasse `Tier` — Stichwort Polymorphie.

Modellantwort:

```csharp
public class Hund {
    public string Name() { return "Bello"; }
    public string Laut() { return "Wuff"; }
    public string StellDichVor() { return Name() + " sagt " + Laut(); }
}

public class Katze {
    public string Name() { return "Minka"; }
    public string Laut() { return "Miau"; }
    public string StellDichVor() { return Name() + " sagt " + Laut(); }
}

public class Zoo {
    public static string Konzert() {
        Hund hund = new Hund();
        Katze katze = new Katze();
        return hund.StellDichVor() + ", " + katze.StellDichVor();
    }
}
```

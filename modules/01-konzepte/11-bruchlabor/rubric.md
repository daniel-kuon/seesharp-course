# Rubrik — Zusatz: Bruchlabor (nur für die Betreuung)

Zusatzaufgabe zu Level 1, angelehnt an das Einleitungsbeispiel
`Einleitungsbeispiel Bruchrechnen/CLI` im Tool-Repository (Baltes-Götz /
Frischknecht, CC BY-NC-SA 4.0); `Frage()` und `Zeige()` sind durch `Text()`
ersetzt, damit nichts von der Konsole liest.

- `NennerNull`: Kernstück. Kann der Trainee erklären, warum der Nenner 1
  bleibt? (Der `set`-Teil der Eigenschaft `Nenner` ignoriert 0 — Kapselung
  setzt eine Regel durch, die ein öffentliches Feld nicht durchsetzen könnte.)
- `EinHalbPlusEinDrittel`: Wer ist Empfänger der Nachricht `Addiere`, wer
  ist Argument? Welches der beiden Objekte ändert sich?
- Hat der Trainee `Bruch.cs` unverändert gelassen?

Modellantwort:

```csharp
public static string KuerzeVierAchtel() {
    Bruch b = new Bruch();
    b.Zaehler = 4;
    b.Nenner = 8;
    b.Kuerze();
    return b.Text();
}

public static string NennerNull() {
    Bruch b = new Bruch();
    b.Zaehler = 3;
    b.Nenner = 0;
    return b.Text();
}

public static string EinHalbPlusEinDrittel() {
    Bruch b1 = new Bruch();
    b1.Zaehler = 1;
    b1.Nenner = 2;
    Bruch b2 = new Bruch();
    b2.Zaehler = 1;
    b2.Nenner = 3;
    b1.Addiere(b2);
    return b1.Text();
}
```

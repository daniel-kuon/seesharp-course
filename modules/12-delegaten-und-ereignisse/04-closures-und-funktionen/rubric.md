# Rubrik — Closures, Func und Action (nur für die Betreuung)

- Kernidee: Ein Lambda fängt **Variablen** ein, nicht Werte. `Zaehler()`:
  jede Variable `n` gehört zu genau einem Delegatenobjekt.
- Falle in `ErzeugeAktionen`: Fängt das Lambda die Schleifenvariable einer
  `for`-Schleife ein, teilen sich alle Aktionen sie und schreiben nach der
  Schleife den Endwert (`4444` statt `3210`). Lösung: Kopie je Durchlauf
  (`int k = i;`) oder `foreach` (seit C# 5 eine frische Variable je Durchlauf).
  Den Fehler gezielt einbauen und die Testausgabe lesen lassen.
- `Komponiere`: Reihenfolge (erst `f`, dann `g`) vom Trainee benennen lassen.
- `Merke`: Das Dictionary lebt in der Closure; Nachfrage: Was passiert bei
  einem Argument, für das `f` eine Ausnahme wirft? (Nichts wird gemerkt.)

Modellantwort: `solution/` bzw. `samples/Delegaten und Ereignisse/Delegaten/Closure`.

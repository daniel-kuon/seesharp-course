# Zusatzaufgabe: Ein binärer Suchbaum mit geschachteltem Knoten

Diese Aufgabe ist freiwillig und die anspruchsvollste in diesem Level. Sie
verbindet geschachtelte Klassen (**5.11**, Seite 391) mit Rekursion
(**5.9.2**, Seite 382).

Ein **binärer Suchbaum** speichert Zahlen in Knoten. Jeder Knoten hat
höchstens zwei Kinder: Im linken Teilbaum stehen nur kleinere Werte, im
rechten nur größere. Wer einen Wert sucht, vergleicht an jedem Knoten und
steigt links oder rechts ab, statt alles zu durchlaufen.

```
        8
      /   \
     3     10
    / \      \
   1   6      14
      / \    /
     4   7  13
```

Der `Knoten` ist eine private geschachtelte Klasse, von außen sieht man nur
`int`-Werte. Öffne `Suchbaum.cs` und vervollständige:

1. `Einfuegen(wert)`: Ist der Baum leer, wird der Wert die Wurzel. Sonst von
   der Wurzel aus absteigen (kleiner: links, größer: rechts), bis der
   passende Platz `null` ist, und dort einen neuen Knoten einhängen. Steht
   der Wert schon im Baum, liefert die Methode `false`.
2. `Enthaelt(wert)`: genauso absteigen; `null` erreicht heißt "nicht da".
3. `Anzahl` mit einer **rekursiven** privaten Hilfsmethode
   `static int Zaehle(Knoten? k)`: ein leerer Teilbaum hat 0 Knoten, sonst
   1 plus die Knoten links plus die Knoten rechts.
4. `Hoehe` ebenso rekursiv: leer 0, sonst 1 plus die größere der beiden
   Teilbaumhöhen (`Math.Max`).
5. `ToString()` liefert alle Werte aufsteigend, getrennt durch ein
   Leerzeichen: rekursiv erst den linken Teilbaum, dann den Knoten, dann
   den rechten (In-Order). Achte auf die Leerzeichen bei leeren Teilbäumen.

Diese Tests müssen bestehen:

- `SuchbaumTests.Leerer_Baum`
- `SuchbaumTests.Einfuegen_lehnt_Duplikate_ab`
- `SuchbaumTests.Enthaelt_findet_eingefuegte_Werte`
- `SuchbaumTests.Anzahl_zaehlt_alle_Knoten`
- `SuchbaumTests.Hoehe_des_Beispielbaums`
- `SuchbaumTests.Sortiert_eingefuegt_entsteht_eine_Kette`
- `SuchbaumTests.ToString_liefert_die_Werte_aufsteigend`
- `SuchbaumTests.Negative_Werte_funktionieren`

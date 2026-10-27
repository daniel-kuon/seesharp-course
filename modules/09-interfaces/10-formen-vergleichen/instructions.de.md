# Zusatz: Formen vergleichen und sortieren

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**9.1.1.2 Konkrete Instanzmethoden** (Seite 616), **9.2.1 Beispiel
IComparable<T>** (Seite 640) und **9.1.4 Vererbung bzw. Erweiterung von
Schnittstellen** (Seite 631) mit 9.1.4.2 zum Ersetzen geerbter
Schnittstellenmethoden (Seite 632).

Kreise, Rechtecke und Dreiecke sollen sich nach ihrer Fläche sortieren
lassen. Statt `CompareTo` dreimal gleich zu schreiben, bringt das Interface
die Implementierung gleich mit. Öffne `IForm.cs`:

1. Ergänze `IForm` um die Eigenschaft `double Umfang { get; }` (`Flaeche`
   steht schon da) und lass das Interface `IComparable<IForm>` erweitern:
   `public interface IForm : IComparable<IForm>`.
2. Implementiere `CompareTo` **im Interface** als konkretes Mitglied. Weil
   `CompareTo` zu `IComparable<IForm>` gehört, steht der Interface-Name
   davor (wie bei der expliziten Implementierung):
   `int IComparable<IForm>.CompareTo(IForm? other) => ...`. Vergleiche die
   Flächen; `null` gilt als kleiner als jede Form.
3. `Kreis(radius)`, `Rechteck(breite, hoehe)` und `Dreieck(a, b, c)`
   implementieren nur `Flaeche` und `Umfang`; `CompareTo` liefert das
   Interface (geerbt wird es nicht; aufrufbar ist es über eine Referenz vom
   Interface-Typ, 9.1.4.3, Seite 634). Die Dreiecksfläche liefert die Formel von Heron:
   `s = (a + b + c) / 2`, Fläche `√(s·(s−a)·(s−b)·(s−c))`. Seiten, die
   kein Dreieck ergeben (eine Seite ist nicht kürzer als die beiden anderen
   zusammen), werfen im Konstruktor `ArgumentException`.
4. `Formen.Sortiert(formen)` liefert eine **neue**, nach Fläche aufsteigend
   sortierte Kopie (das Original bleibt unverändert; `Array.Sort` hilft,
   weil `IForm` jetzt vergleichbar ist). `Formen.Groesste(formen)` liefert
   die Form mit der größten Fläche oder `null` für ein leeres Array.

Diese Tests müssen bestehen:

- `FormenVergleichenTests.IForm_erweitert_IComparable`
- `FormenVergleichenTests.Flaeche_und_Umfang`
- `FormenVergleichenTests.Ungueltiges_Dreieck_wirft`
- `FormenVergleichenTests.CompareTo_vergleicht_die_Flaechen`
- `FormenVergleichenTests.CompareTo_steckt_im_Interface`
- `FormenVergleichenTests.Sortiert_liefert_eine_sortierte_Kopie`
- `FormenVergleichenTests.Groesste_findet_die_groesste_Form`

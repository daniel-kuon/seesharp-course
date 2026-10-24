# Rubrik — Delegaten-Grundlagen (nur für die Betreuung)

- Kernidee: Ein Delegatenobjekt = Methode + Zielobjekt. Bei der Instanzmethode
  `Potenz` bleibt das Zielobjekt erhalten; der Test ändert `Exponent` nach dem
  Erzeugen des Delegaten und erwartet das neue Ergebnis.
- Der Delegatentyp `Operation` ist vorgegeben, damit Starter und Tests
  gemeinsam kompilieren; das Deklarieren selbst übt das Review-Item
  (`Bedingung`: Signatur `bool (double)`).
- `Waehle`: `'+' => Addiere` ist eine Methodengruppenkonvertierung, kein Aufruf.
  Typischer Fehler: `Addiere()` mit Klammern.
- Nachfrage: Was liefert `Bedingung b = null; b(1)`? (NullReferenceException;
  Vorgriff auf 12/02.) Wo steht der Delegatentyp im Typsystem? (Klasse, die von
  `MulticastDelegate` erbt; der Aufruf ist `Invoke`.)

Modellantwort: `solution/` bzw. `samples/Delegaten und Ereignisse/Delegaten/DemoGate`.

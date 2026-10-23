# Rubrik — Zusatzaufgabe Textspiele (nur für die Betreuung)

- `IstPalindrom`: Die Zwei-Index-Fassung kommt ohne Hilfsstring aus. Wer
  erst alle Buchstaben in einen neuen String sammelt und mit der Umkehrung
  vergleicht, ist auch richtig; im Gespräch den Speicherbedarf vergleichen.
  Bezug zur lokalen Palindrom-Methode aus der Enum/Tupel-Übung.
- `IstAnagramm`: Sortieren ist die kürzeste Lösung. Alternative mit einem
  Zähl-Array wie bei `Caesar.Haeufigkeiten` geht nur für a–z, nicht für
  Umlaute. Vergleich zweier `char[]` mit `==` vergleicht Referenzen
  (Level 4/6!), deshalb `new string(...)` oder elementweise.
- `Kodiere`: häufigster Fehler ist der letzte Lauf, der nach der Schleife
  nicht mehr angehängt wird. Die Fassung mit innerer `while`-Schleife
  vermeidet das.
- `Dekodiere`: `zahl * 10 + (c - '0')` ist die klassische
  Ziffernakkumulation. Wer `int.Parse` auf Teilstrings benutzt, ist auch
  richtig.
- Der Test `Dekodiere_hebt_Kodiere_auf` enthält Leerzeichen und Punkte:
  Kodierung muss mit beliebigen Nicht-Ziffern funktionieren.

Modellantwort: `solution/Textspiele/Wortspiele.cs`.

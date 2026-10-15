# Explizite Schnittstellenimplementierung

Lies im Buch **9.4 Explizite Schnittstellenimplementierung** (Seite 646)
und **9.1.4.3 Mehrfachvererbung** (Seite 634): Eine Klasse kann beliebig
viele Interfaces implementieren.

`IZaehler` und `IMesser` verlangen beide eine Methode `Wert()`, meinen aber
Verschiedenes. Mit einer einzigen öffentlichen `Wert()`-Methode bedient
`Sensor` zwar beide Verträge, kann aber nicht unterscheiden. Öffne
`Sensor.cs`:

1. `Sensor`: Implementiere beide Mitglieder **explizit** mit dem
   Interface-Namen davor und ohne Zugriffsmodifizierer:
   `int IZaehler.Wert() => 1;` und `int IMesser.Wert() => 2;`. Danach gibt
   es kein `s.Wert()` mehr; der Aufruf geht nur über eine Interface-Referenz
   (`((IZaehler)s).Wert()` oder `(s as IMesser).Wert()`).
2. `Geraet`: Eine öffentliche (implizite) Implementierung liefert 1 und
   bedient zugleich `IZaehler`; eine explizite Implementierung für
   `IMesser` liefert 2.

In `Program.cs` kannst du beobachten, dass `s.Wert()` nach dem Umbau nicht
mehr kompiliert.

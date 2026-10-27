# Rubrik — Ereignisse anbieten (nur für die Betreuung)

- Kernidee: `event` kapselt ein Delegatenfeld: von außen nur `+=`/`-=`,
  Auslösen nur in der eigenen Klasse. Ein öffentliches Delegatenfeld (Startzustand)
  erlaubt `t.Ueberhitzt = null` und `t.Ueberhitzt(...)` von außen; der
  Reflexionstest `Ereignisse_sind_echte_Ereignisse` fängt das ab.
- Muster merken lassen: Ereignis `Xyz`, Auslösemethode `protected virtual void
  OnXyz(XyzEventArgs e) => Xyz?.Invoke(this, e);`, Auslösen im Setter.
- Typische Fehler: Auslösen ohne `?.`, Auslösen bei unverändertem Wert,
  `sender` mit `null` oder einem anderen Objekt belegt, `Ueberhitzt` bei
  `Neu == Grenze`.
- Der Erben-Test überschreibt `OnTemperaturGeaendert` und ruft `base` auf;
  Nachfrage: Was geschieht, wenn der Erbe `base` nicht aufruft?

Modellantwort: `solution/` bzw. `samples/Delegaten und Ereignisse/Ereignisse/EventPublisher`.

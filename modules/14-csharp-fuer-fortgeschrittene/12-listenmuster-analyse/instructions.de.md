# Zusatz: Muster in Messreihen

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**15.2.10 Listenmuster** (Seite 985) mit **15.2.10.1 Ausschuss- und
Bereichsmuster** und **15.2.8 Relationsmuster** (Seite 983).

In `Messreihe.cs` beschreibst du Messreihen allein durch Muster:

1. `Trend(int[] werte)`: ein `switch`-Ausdruck, dessen Arme in dieser
   Reihenfolge stehen: `[]` ergibt `"leer"`, ein einzelner Wert
   `"einzeln"`, drei streng aufsteigende Werte
   (`[var a, var b, var c] when a < b && b < c`) `"steigend"`, eine
   Reihe beliebiger Länge, deren letzter Wert über 100 liegt
   (`[.., > 100]`), `"Ausreißer am Ende"`, alles andere `"sonstige"`.
2. `Kopf(List<string>)`: liefert mit `[var kopf, .. var rest]` das erste
   Element und die Anzahl der restlichen als Tupel; für eine leere Liste
   `(null, 0)`.

Diese Tests müssen bestehen:

- `MessreiheTests.Trend_leer_und_einzeln`
- `MessreiheTests.Trend_steigend_bei_drei_streng_aufsteigenden_Werten`
- `MessreiheTests.Trend_steigend_hat_Vorrang_vor_dem_Ausreisser`
- `MessreiheTests.Trend_Ausreisser_am_Ende`
- `MessreiheTests.Kopf_zerlegt_die_Liste`

# Ereignisse anbieten

Lies im Buch **10.2 Ereignisse** (Seite 678) und **10.2.3 Ereignisse
anbieten** (Seite 684 bis 686).

Ein Ereignis (`event`) ist ein Delegat, den fremde Klassen nur mit `+=` und
`-=` ändern, aber nicht selbst aufrufen dürfen. Öffne `Thermostat.cs`:

1. `TemperaturGeaendertEventArgs`: Die Klasse trägt `Alt` und `Neu`. Leite sie
   von `EventArgs` ab und schreibe den Konstruktor.
2. `Thermostat`: In der Vorgabe sind `TemperaturGeaendert` und `Ueberhitzt`
   öffentliche **Felder** vom Delegatentyp. Mache daraus Ereignisse
   (`event`): `EventHandler<TemperaturGeaendertEventArgs>` und
   `EventHandler`.
3. `OnTemperaturGeaendert` und `OnUeberhitzt` (`protected virtual`) lösen
   die Ereignisse mit `?.Invoke(this, e)` aus; `sender` ist das Thermostat.
4. Der Setter von `Temperatur` tut nur etwas, wenn sich der Wert wirklich
   ändert: Er setzt den Wert, löst `TemperaturGeaendert` aus (mit altem und
   neuem Wert) und, wenn der neue Wert **größer** als `Grenze` ist, danach
   `Ueberhitzt`.

Tests: `Aenderung_loest_TemperaturGeaendert_aus`,
`Gleicher_Wert_loest_nichts_aus`, `Ohne_Abonnenten_passiert_nichts`,
`Mehrere_Abonnenten_werden_benachrichtigt`,
`Ueberhitzt_nur_ueber_der_Grenze`,
`Ueberhitzt_kommt_nach_TemperaturGeaendert`,
`Erben_koennen_die_Ausloesung_kontrollieren`,
`Ereignisse_sind_echte_Ereignisse`,
`EventArgs_sind_von_EventArgs_abgeleitet`.

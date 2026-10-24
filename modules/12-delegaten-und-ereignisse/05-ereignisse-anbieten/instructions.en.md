# Providing Events

Read sections **10.2 "Events**" (page 678) and **10.2.3 "Offering Events"** (pages 684–686) in the book.

An `event` is a delegate that external classes may only modify using `+=` and `-=`, but may not call themselves. Open `Thermostat.cs`:

1. `TemperaturGeaendertEventArgs`: The class has `Alt` and `Neu` properties. Derive it from `EventArgs` and implement the constructor.
2. `Thermostat`: In the starter, `TemperaturGeaendert` and `Ueberhitzt` are public **fields** of the delegate type. Turn them into events (`event`): `EventHandler<TemperaturGeaendertEventArgs>` and `EventHandler`.
3. `OnTemperaturGeaendert` and `OnUeberhitzt` (`protected virtual`) trigger the events using `?.Invoke(this, e)`; `sender` is the thermostat.
4. The `Temperatur` setter only does anything if the value actually changes: It sets the value, triggers `TemperaturGeaendert` (with the old and new values), and, if the new value is **greater** than `Grenze`, then triggers `Ueberhitzt`.

Tests: `Aenderung_loest_TemperaturGeaendert_aus`, `Gleicher_Wert_loest_nichts_aus`, `Ohne_Abonnenten_passiert_nichts`, `Mehrere_Abonnenten_werden_benachrichtigt`, `Ueberhitzt_nur_ueber_der_Grenze`, `Ueberhitzt_kommt_nach_TemperaturGeaendert`, `Erben_koennen_die_Ausloesung_kontrollieren`, `Ereignisse_sind_echte_Ereignisse`, `EventArgs_sind_von_EventArgs_abgeleitet`.

# Ereignisse abonnieren und abmelden

Lies im Buch **10.2.2 Behandlungsmethoden registrieren** (Seite 681) und die
Übungsaufgabe **10.3 Aufgabe 4** (Seite 688).

Eine Behandlungsmethode für ein `EventHandler<TEventArgs>`-Ereignis hat die
Parameter `(object? sender, TEventArgs e)`. `sender` ist das Objekt, das das
Ereignis ausgelöst hat. Öffne `Alarmzentrale.cs`; `Sensor` und
`AlarmEventArgs` sind vorgegeben:

1. `Ueberwache(sensor)` meldet die Instanzmethode `BeiAlarm` am Ereignis
   `Alarm` an, `Entferne(sensor)` meldet sie wieder ab.
2. `BeiAlarm(sender, e)` wertet `sender` aus (Umwandlung in `Sensor`, andere
   Absender ignorieren) und zählt die Alarme je `Sensor.Name` in einem
   `Dictionary<string, int>`. `HoechsterWert` merkt den größten `e.Wert` aller
   Alarme (`null`, solange es keinen gab). `Anzahl(name)` liefert 0 für unbekannte
   Namen.
3. `UeberwacheHohe(sensor, schwelle)` meldet ein **Lambda** an, das nur Werte
   `>= schwelle` in `HoheAlarme` zählt. Damit `EntferneHohe(sensor)` es wieder
   abmelden kann, speichere das Lambda in einem Dictionary (Sensor ->
   Handler). Ein neues Lambda mit gleichem Text würde nicht abmelden.

Tests: `Zaehlt_Alarme_je_Sensor`, `Merkt_den_hoechsten_Wert`,
`Hoechster_Wert_kann_negativ_sein`,
`Nach_Entferne_wird_nicht_mehr_gezaehlt`,
`Zweimal_ueberwachen_zaehlt_zweimal`,
`Entferne_meldet_nur_ein_Abonnement_ab`,
`Unbekannter_Sensor_hat_Anzahl_null`, `Fremder_Absender_wird_ignoriert`,
`Hohe_Alarme_werden_gezaehlt`, `EntferneHohe_meldet_das_Lambda_wirklich_ab`,
`EntferneHohe_ohne_Anmeldung_ist_harmlos`.

# Subscribe to and Unsubscribe from Events

Read section **10.2.2, “Recording Treatment Methods**” (page 681), and exercise **10.3**, **Task 4** (page 688).

A handler for an `EventHandler<TEventArgs>` event has the parameters `(object? sender, TEventArgs e)`. `sender` is the object that triggered the event. Open `Alarmzentrale.cs`; `Sensor` and `AlarmEventArgs` are predefined:

1. `Ueberwache(sensor)` calls the instance method `BeiAlarm` on the `Alarm` event; `Entferne(sensor)` deregisters it.
2. `BeiAlarm(sender, e)` evaluates `sender` (converts it to a `Sensor`; ignores other senders) and counts the alarms for each `Sensor.Name` in a `Dictionary<string, int>`. `HoechsterWert` records the largest `e.Wert` value of all alarms (`null` if there were none). `Anzahl(name)` returns 0 for unknown names.
3. `UeberwacheHohe(sensor, schwelle)` registers a **lambda** that counts only values `>= schwelle` in `HoheAlarme`. To allow `EntferneHohe(sensor)` to unregister it, store the lambda in a dictionary (Sensor -> Handler). A new lambda with the same text would not unregister it.

Tests: `Zaehlt_Alarme_je_Sensor`, `Merkt_den_hoechsten_Wert`, `Hoechster_Wert_kann_negativ_sein`, `Nach_Entferne_wird_nicht_mehr_gezaehlt`, `Zweimal_ueberwachen_zaehlt_zweimal`, `Entferne_meldet_nur_ein_Abonnement_ab`, `Unbekannter_Sensor_hat_Anzahl_null`, `Fremder_Absender_wird_ignoriert`, `Hohe_Alarme_werden_gezaehlt`, `EntferneHohe_meldet_das_Lambda_wirklich_ab`, `EntferneHohe_ohne_Anmeldung_ist_harmlos`.

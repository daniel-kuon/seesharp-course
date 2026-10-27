# Rubrik — Ereignisse abonnieren und abmelden (nur für die Betreuung)

- Kernidee: Anmelden und Abmelden sind symmetrisch (`+=` / `-=`) und arbeiten
  mit **gleichen Delegatenobjekten** (gleiche Methode, gleiches Ziel).
  Für Lambdas heißt das: in Variable oder Feld aufbewahren.
- `sender`: Ein harter Cast `(Sensor)sender!` scheitert am Test
  `Fremder_Absender_wird_ignoriert` (InvalidCastException bzw.
  NullReferenceException), der `BeiAlarm` direkt mit einem anderen Absender
  und mit `null` aufruft; nötig ist `sender is Sensor s` (7.8).
- Doppeltes `+=` meldet zweimal an; ein `-=` nimmt nur einen Eintrag heraus
  (wie bei 12/02).
- Nachfrage: Was passiert mit einer Alarmzentrale, die nie `Entferne` ruft,
  wenn die Sensoren länger leben? (Speicher, Phantom-Benachrichtigungen.)
- `UeberwacheHohe` zweimal für denselben Sensor aufzurufen ist nicht
  vorgesehen; wer es abfängt (alten Handler zuerst abmelden), liegt richtig.

Modellantwort: `solution/` bzw. `samples/Delegaten und Ereignisse/Ereignisse/EventPublisher`.

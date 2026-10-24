# Zusatz: Lichtschalter mit Ereignissen

Lies im Buch **10.2 Ereignisse** (Seite 678) und wiederhole **10.2.2**
(Seite 681) zum Registrieren und Abmelden.

Ein `Lichtschalter` meldet, wenn er ein- oder ausgeschaltet wird; eine `Lampe`
hört zu. Öffne `Lichtschalter.cs`:

1. `Lichtschalter`: Mache aus den öffentlichen Delegatenfeldern `Eingeschaltet`
   und `Ausgeschaltet` echte Ereignisse (`event EventHandler?`).
   `Umschalten()` kehrt `IstAn` um und löst danach das passende Ereignis aus
   (`?.Invoke(this, EventArgs.Empty)`); ohne Abonnenten darf nichts passieren.
2. `Lampe`: Der Konstruktor meldet zwei Behandlungsmethoden am Schalter an;
   `Einschaltungen` und `Ausschaltungen` zählen mit. `Abkoppeln()` meldet
   beide wieder ab.

Tests: `Umschalten_kehrt_IstAn_um`, `Ohne_Abonnenten_passiert_nichts`,
`Ereignis_sieht_den_neuen_Zustand`,
`Zehnmal_umschalten_zaehlt_fuenf_und_fuenf`,
`Nach_Abkoppeln_wird_nicht_mehr_gezaehlt`, `Zwei_Lampen_sind_unabhaengig`,
`Ereignisse_sind_echte_Ereignisse`.

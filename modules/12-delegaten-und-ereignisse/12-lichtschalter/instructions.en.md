# Extra: Light Switches with Events

Read **10.2 Events** (page 678) in the book and review **10.2.2** (page 681) on registering and unregistering.

A `Lichtschalter` (light switch) reports when it is switched on or off; a `Lampe` (lamp) listens. Open `Lichtschalter.cs`:

1. `Lichtschalter`: Turn the public delegate fields `Eingeschaltet` and `Ausgeschaltet` into actual events (`event EventHandler?`). `Umschalten()` flips `IstAn` and then triggers the corresponding event (`?.Invoke(this, EventArgs.Empty)`); nothing should happen without subscribers.
2. `Lampe`: The constructor registers two handler methods with the switch; `Einschaltungen` and `Ausschaltungen` keep count. `Abkoppeln()` deregisters both.

Tests: `Umschalten_kehrt_IstAn_um`, `Ohne_Abonnenten_passiert_nichts`, `Ereignis_sieht_den_neuen_Zustand`, `Zehnmal_umschalten_zaehlt_fuenf_und_fuenf`, `Nach_Abkoppeln_wird_nicht_mehr_gezaehlt`, `Zwei_Lampen_sind_unabhaengig`, `Ereignisse_sind_echte_Ereignisse`.

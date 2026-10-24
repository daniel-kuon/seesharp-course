# Extra: Light Switches with Events

Read **Section 10.2**, "**Events"** (page 678), in the book, and review **Section 10.2.2** (page 681) on logging in and out.

A light `Lichtschalter` sends a message when it is turned on or off; a `Lampe` stops emitting light. Open `Lichtschalter.cs`:

1. `Lichtschalter`: Turn the public delegate fields `Eingeschaltet` and `Ausgeschaltet` into actual events (`event EventHandler?`). `Umschalten()` flips `IstAn` and then triggers the corresponding event (`?.Invoke(this, EventArgs.Empty)`); nothing should happen without subscribers.
2. `Lampe`: The constructor registers two handling methods with the switch; both `Einschaltungen` and `Ausschaltungen` are counted. `Abkoppeln()` deregisters both.

Tests: `Umschalten_kehrt_IstAn_um`, `Ohne_Abonnenten_passiert_nichts`, `Ereignis_sieht_den_neuen_Zustand`, `Zehnmal_umschalten_zaehlt_fuenf_und_fuenf`, `Nach_Abkoppeln_wird_nicht_mehr_gezaehlt`, `Zwei_Lampen_sind_unabhaengig`, `Ereignisse_sind_echte_Ereignisse`.

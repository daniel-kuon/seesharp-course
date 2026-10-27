# Deep Dive: Ein Mini-Testläufer

> **Deep Dive (optional):** Methoden per Reflexion aufrufen (`MethodInfo.Invoke`,
> `TargetInvocationException`) und `GetMethods` stehen nicht im Buch. Diese
> Aufgabe ist ein Hinweis, womit du dich als Nächstes beschäftigen kannst; die
> Werkzeuge beschreibt der Deep Dive in Aufgabe 16/04.

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**14.2 Attribute per Reflexion auswerten** (Seite 924) und das Beispiel
`PersistenceHelper` in **14.7.1** (Seite 942).

Das Testwerkzeug, mit dem SeeSharp deine Aufgaben prüft, arbeitet im Kern
genauso, wie du es hier selbst baust: Es sucht per Reflexion alle Methoden
mit einem Attribut, ruft sie auf und sammelt die Ergebnisse. Das Attribut
`[MeinTest]` ist vorgegeben; `Beispiel.cs` enthält eine Testklasse zum
Ausprobieren.

`Laeufer.Starte(Type t)` führt alle Tests der Klasse `t` aus:

1. Es wird **eine** Instanz von `t` erzeugt (`Activator.CreateInstance`),
   alle Tests laufen auf ihr.
2. Tests sind die öffentlichen Instanzmethoden ohne Parameter, die
   `[MeinTest]` tragen. Alle anderen Methoden bleiben unbeachtet.
3. Sie laufen in der Reihenfolge ihrer Namen (`StringComparer.Ordinal`).
4. Wirft eine Methode eine Ausnahme, ist der Test nicht bestanden und die
   übrigen laufen weiter. `MethodInfo.Invoke` verpackt die Ausnahme in eine
   `TargetInvocationException`: Fang diese.
5. Das Ergebnis ist eine Liste aus `(Name, Bestanden)`; ohne Tests eine
   leere Liste.

Diese Tests müssen bestehen:

- `TestlaeuferTests.Liefert_pro_Test_Name_und_Ergebnis_nach_Namen_sortiert`
- `TestlaeuferTests.Nur_oeffentliche_parameterlose_Instanzmethoden_mit_Attribut_zaehlen`
- `TestlaeuferTests.Alle_Tests_laufen_auf_derselben_Instanz_in_Namensreihenfolge`
- `TestlaeuferTests.Eine_Ausnahme_bricht_die_uebrigen_Tests_nicht_ab`
- `TestlaeuferTests.Eine_Klasse_ohne_Tests_ergibt_eine_leere_Liste`

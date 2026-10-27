# The right collection; read-only and immutable

Read **11.7 Immutable Collections** (page 716) in the book, along with **11.1 Arrays versus Collections** (page 691) and the exercises in **11.8** (page 723).

**Part 1: Programming.** Open `Kurs.cs`. A `Kurs` keeps its participants in a private `List<string>`. Expose them in two ways:

1. `Teilnehmer` returns a read-only **view** (`AsReadOnly()`). Whoever gets it cannot change anything but sees later enrolments. Do not return the list itself as an `IReadOnlyList<string>`: the caller could cast it back to a list and change it. The test checks this.
2. `Schnappschuss()` returns an `ImmutableList<string>` (the `using System.Collections.Immutable;` directive is already in the file). It is a **copy** taken at the time of the call and does not see later enrolments.
3. `MitTeilnehmer(liste, name)` shows that `Add()` on an immutable list returns a **new** list; the old one stays as it was.

**Part 2: Questions.** Then answer the questions: the statements from book exercise 11.8 No. 1, six scenarios (which collection fits?) and the question about the twelve months.

Tests: `Teilnehmer_ist_eine_Sicht_und_sieht_spaetere_Anmeldungen`, `Teilnehmer_gibt_nicht_die_List_selbst_heraus`, `Schnappschuss_sieht_spaetere_Anmeldungen_nicht` and `MitTeilnehmer_liefert_eine_neue_Liste_und_laesst_das_Original_unveraendert`.

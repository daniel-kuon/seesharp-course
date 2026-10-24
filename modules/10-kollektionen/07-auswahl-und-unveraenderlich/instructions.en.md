# The correct collection; read-only and immutable

Read Section **11.7**, **“Immutable Collections”** (page 716), along with **Section 11.1, “Arrays versus Collections”** (page 691), and the exercises in Section **11.8** (page 723).

**Part 1: Programming.** Open `Kurs.cs`. A `Kurs` manages its participants in a private `List<string>`. Expose it in two ways:

1. `Teilnehmer` returns a read-only **view** (`AsReadOnly()`). Anyone who receives it cannot make any changes, but can see subsequent logins. Do not return the list itself as an `IReadOnlyList<string>`: The caller could cast it back to a list and modify it. The test checks for this.
2. `Schnappschuss()` returns an `ImmutableList<string>` (the `using System.Collections.Immutable;` assembly is already included in the file). It is a **copy** taken at the time of the call and does not see any subsequent additions.
3. `MitTeilnehmer(liste, name)` shows that `Add()`, when applied to an immutable list, returns a **new** list; the original list remains unchanged.

**Part 2: Questions.** Answer the following questions: the statements from textbook exercise 11.8, No. 1; the six scenarios (which collection is a good fit?); and the question about the twelve months.

Tests: `Teilnehmer_ist_eine_Sicht_und_sieht_spaetere_Anmeldungen`, `Teilnehmer_gibt_nicht_die_List_selbst_heraus`, `Schnappschuss_sieht_spaetere_Anmeldungen_nicht`, and `MitTeilnehmer_liefert_eine_neue_Liste_und_laesst_das_Original_unveraendert`.

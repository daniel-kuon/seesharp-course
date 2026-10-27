# Troubleshooting in Branches

Read Section **4.7.2**, **“Conditional Statements and Case Distinctions”** (page 253), in the book, especially 4.7.2.1 and 4.7.2.2 on the `if` and `if-else` statements and the dangling else (pages 254 to 258). Exercises 1, 2, and 4 in **Section 4.7.4** (page 281) serve as a template.

Open *`Fehlersuche.cs`*. Both methods compile, but return incorrect results. Find the cause before making any changes:

1. `Gewinn(int losNr)`: A lottery pays 100 euros for ticket numbers divisible by 13, and 1 euro for ticket numbers that are not divisible by 13 but are divisible by 7; otherwise, nothing. The current version incorrectly places the `else` statement. Rewrite it as a chain of `else if` statements.
2. `Beschreibe(bool b)`: is supposed to return `"b ist False"` or `"b ist True"`, but claims the opposite for `false`. Take a close look at the condition.

Then answer the two questions.

The following tests must be passed:

- `FehlersucheTests.Durch_13_teilbar_gewinnt_100`
- `FehlersucheTests.Nur_durch_7_teilbar_gewinnt_1`
- `FehlersucheTests.Durch_7_und_13_teilbar_gewinnt_100`
- `FehlersucheTests.Sonst_gewinnt_nichts`
- `FehlersucheTests.Beschreibe_false`
- `FehlersucheTests.Beschreibe_true`

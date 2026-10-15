# seesharp-course

Course content for [SeeSharp](https://github.com/daniel-kuon/seesharp). The tool
reads this repository from disk; nothing here is compiled into the tool.

Layout and schema: `docs/CONTENT-FORMAT.md` in the tool repository.
Skill vocabulary: `skills.yaml`, documented in `docs/SKILLS.md`.

Validate with:

```bash
seesharp validate .
```

## Musterlösungen

Jede Programmierübung enthält neben `starter/` und `tests/` einen Ordner
`solution/` mit der Modellantwort im gleichen Projektlayout wie `starter/`.
Er ist, wie `rubric.md`, nur für die Betreuung gedacht: SeeSharp rendert ihn
nicht, und beim Bewerten wird ausschließlich `tests/` über die Abgabe gelegt.
Prüfen lässt sich eine Musterlösung mit

```bash
seesharp grade <übung>/tests <übung>/solution
```

## Licence

CC BY-NC-SA 4.0. Summaries and exercises are condensed derivative works of
*Einführung in das Programmieren mit C# 14* by Bernhard Baltes-Götz and Paul
Frischknecht, published under the same licence.

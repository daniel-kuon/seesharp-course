# Rubrik — Reflexion nutzen (nur für die Betreuung)

- Kern: Reflexion macht aus Zeichenketten Code-Zugriffe: Eigenschaft per
  Name lesen und setzen, Methode per Name aufrufen, Objekt per Typname
  erzeugen. Dahinter steckt das Muster jedes Frameworks (Serialisierer,
  Datenbank-Mapper, Plugin-Systeme): Typen werden zur Laufzeit entdeckt,
  nicht zur Übersetzungszeit festgelegt.
- Das Buch zeigt nur `Activator` (Seite 943); `PropertyInfo.SetValue` und
  `MethodInfo.Invoke` kommen aus der Aufgabenstellung. Bei Rückfragen auf die
  Dokumentation verweisen lassen.
- `CultureInfo.InvariantCulture`: Zwei Tests schalten die Kultur auf
  `de-DE`; wer `ToString()` ohne Kultur nimmt, schreibt `2,5` und liest
  `1.5` falsch. Gesprächsanlass: Daten, die zwischen Programmen oder
  Sprachräumen wandern, immer invariant formatieren.
- `GetMethod(name)` ohne Typenliste wirft `AmbiguousMatchException`, sobald es
  zwei Überladungen gibt (`Gruss()` und `Gruss(string)` im Test). Die
  parameterlose Überladung verlangt `Type.EmptyTypes`.
- `Invoke` verpackt eine Ausnahme der Methode in `TargetInvocationException`;
  die Aufgabe verlangt hier bewusst keine Behandlung (Zusatzaufgabe 12
  fängt sie ab). Kurz fragen, ob die Abgabe damit rechnet.
- `PluginFabrik`: Das Erzeugen fremder Typen aus Text ist ein
  Sicherheitsthema; die Prüfung mit `IsAssignableFrom` begrenzt es auf
  Typen, die ein bestimmtes Interface erfüllen. Die Frage "Was, wenn der
  Typ keinen parameterlosen Konstruktor hat?" lässt sich vertiefen
  (`MissingMethodException`).
- Ergänzung zur Aufgabe: Der Fehlerfall "Wert nicht umwandelbar" ist
  zusätzlich zur Reflexion eine kleine Übung zu `try/catch` mit
  Ausnahmefilter (`when`).

Modellantwort: `solution/`.

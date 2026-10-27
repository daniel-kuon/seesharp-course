# Rubrik: Verständnisfragen, Ausnahmebehandlung (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `weiterreichen-richtig` = `throw;`, `try-syntax` = spezifischer `catch`,
dann allgemeiner, dann `finally`, `eigene-ausnahme-richtig` = Ableitung von `Exception` mit
`: base(message)`, `aufraeumen` = `finally`).

## vermeiden-abfangen

Wesentliche Punkte:
- Ein Fehler, den man **vorher ausschließen** kann, wird vorher geprüft, statt die Ausnahme zu
  fangen: `if (b != 0) ergebnis = a / b;` statt `try { a / b } catch (DivideByZeroException)`.
  Eine Prüfung ist billig, eine Ausnahme teuer (Stapelüberwachung aufbauen und abbauen) und
  macht den Ablauf unübersichtlich.
- Ausnahmen sind für Fehler gedacht, die man **nicht sinnvoll vorher ausschließen** kann
  oder die **selten** sind: fehlende Datei, Netzwerkausfall, ein Argument, das eine Methode
  nicht erfüllen kann (ungültige Vorbedingung), Fehler tief in einer Aufrufkette, den erst
  eine höhere Methode behandeln kann.

Typische Missverständnisse: "Ausnahmen sind immer die beste Technik" oder "man fängt am besten
alles ab"; häufige Fehler (Tippfehler bei der Eingabe) per Ausnahme zu melden.

## catch-reihenfolge

Wesentliche Punkte:
- Die `catch`-Blöcke werden **von oben nach unten** geprüft; der **erste passende** gewinnt.
- Spezifische Klassen kommen **vor** allgemeinen: `DivideByZeroException` erbt von
  `ArithmeticException`. Stünde der allgemeine Block zuerst, würde er alles abfangen und der
  spezielle wäre unerreichbar: **Compilerfehler** (CS0160).
- Ausnahmefilter `catch (… ex) when (Bedingung)`: Der Block fängt die Ausnahme **nur**, wenn
  die Bedingung zutrifft; sonst läuft sie weiter nach oben (der Stapel wird nicht abgebaut).

Typische Missverständnisse: Die Laufzeit suche den "besten" Block (sie nimmt den ersten
passenden); die falsche Reihenfolge sei nur eine Warnung oder ein Laufzeitfehler.

## finally-wann

Wesentliche Punkte:
- `finally` läuft **(fast) immer**: nach normalem Ende des `try`-Blocks, nach einem Verlassen durch
  `return` (der Rückgabewert ist dann schon berechnet) und nach einer Ausnahme, auch wenn kein
  `catch` dieses `try` passt und die Ausnahme zu einer äußeren Methode weiterwandert (jedes
  `finally` auf dem Weg nach oben läuft). Verhindern können es nur eine Endlosschleife
  oder `Environment.Exit()` (13.3.1.3, Seite 895); das muss die Antwort nicht nennen.
- Verwendung: **Aufräumarbeiten**, die unabhängig vom Ergebnis passieren müssen: Datei oder
  Verbindung **schließen**, Ressource freigeben.
- Beispiel: Eine Datei im `try` lesen, im `finally` schließen.

Typische Missverständnisse: `finally` laufe nur bei einer Ausnahme (oder nur ohne); ein
`return` im `try` überspringe das `finally`.

## weiterreichen-verpacken

Wesentliche Punkte:
- **`throw;`** reicht **dieselbe** Ausnahme weiter und **behält** die ursprüngliche
  Stapelüberwachung (sie zeigt, wo der Fehler wirklich entstand).
- **`throw ex;`** wirft die Ausnahme **neu** und **überschreibt** die Stapelüberwachung: Der
  Ursprung geht verloren; ein klassischer Fehler.
- Verpacken: Wenn man eine **aussagekräftigere** Ausnahme auf der Ebene der eigenen Methode
  werfen will (`throw new InvalidOperationException("…", ex);`), gibt man die ursprüngliche
  als **zweites Argument** mit; sie ist dann als **`InnerException`** abrufbar, die Ursache
  geht nicht verloren.

Typische Missverständnisse: `throw ex;` sei dasselbe wie `throw;`; die neue Ausnahme ohne
Ursache zu werfen (`new Exception(ex.Message)`) sei gleichwertig.

## eigene-ausnahme

Wesentliche Punkte:
- Eine eigene Klasse lohnt sich, wenn der Fänger **gezielt auf diesen Fehler reagieren** will
  (eigener `catch`) oder **fachliche Zusatzinformationen** braucht, die keine BCL-Ausnahme
  trägt. Ein einzelnes Detail kann auch die `Data`-Kollektion einer BCL-Ausnahme tragen.
- Ableitung von **`Exception`** (oder einer passenden Unterklasse). Üblich sind die Konstruktoren
  **`()`**, **`(string)`** und **`(string, Exception)`**, die per `: base(...)` weiterreichen
  (die Meldung bleibt in `Message`, die Ursache in `InnerException`).
- Zusatzinformationen als **Eigenschaften** (z. B. `Betrag`), die der Konstruktor setzt; der
  Fänger liest sie über die Fangvariable.

Typische Missverständnisse: Die Klasse müsse nicht von `Exception` erben; `: base(message)`
vergessen (die Meldung geht verloren).

## code-finally-return

Ausgabe, drei Zeilen: `try`, `finally`, `ergebnis`
- `F()` läuft: `try` wird ausgegeben, der `return`-Wert `"ergebnis"` wird berechnet.
- **Bevor** die Methode wirklich zurückkehrt, läuft das `finally`: `finally`.
- Erst danach gibt `WriteLine` den Rückgabewert aus: `ergebnis`.

Typische Fehler: `ergebnis` vor `finally` (der Aufruf von `WriteLine(F())` braucht den
Rückgabewert erst nach dem Rücksprung); `finally` fehle (Überspringen durch `return`).

## code-catch-reihenfolge

Ausgabe, zwei Zeilen: `durch null`, `ende`
- `10 / 0` bei `int` löst `DivideByZeroException` aus; `WriteLine(Teile(10, 0))` gibt
  deshalb nichts aus.
- Der erste passende Block ist `catch (DivideByZeroException)`: `durch null`. Der
  `ArithmeticException`-Block wird nicht betreten.
- `finally` läuft immer: `ende`.
- Vertauscht: Compilerfehler CS0160: Der erste Block fängt schon alle Ausnahmen dieses und
  der abgeleiteten Typen; der spezielle Block wäre nie erreichbar.

Typische Fehler: `arithmetik` ausgegeben (der Block mit dem "besseren" Typ); `ende` fehle.

## code-innere-ausnahme

Ausgabe, zwei Zeilen: `InvalidOperationException: Eingabe ungültig`, `FormatException`
- `int.Parse("abc")` löst eine `FormatException` aus; der innere `catch` fängt sie.
- Er wirft eine **neue** `InvalidOperationException("Eingabe ungültig", ex)` und gibt die
  `FormatException` als zweites Argument mit.
- Der äußere `catch (Exception ex)` fängt die neue Ausnahme: `GetType().Name` liefert
  `InvalidOperationException`, `Message` ist `Eingabe ungültig`.
- `InnerException` ist die ursprüngliche `FormatException`: zweite Zeile.

Typische Fehler: `FormatException` in der ersten Zeile (die äußere Ausnahme verwechselt); die
zweite Zeile fehle (kein Verständnis von `InnerException`).

## code-throw-ausdruck

Ausgabe, zwei Zeilen: `Null: s`, `3`
- `Laenge(null)`: `s ?? throw …`: Ist `s` `null`, wird der `throw`-Ausdruck ausgewertet und eine
  `ArgumentNullException` geworfen; sonst steht der Wert von `s` da. Der `catch` gibt
  `Null: ` plus `ParamName` aus.
- `nameof(s)` liefert den **Parameternamen als Text** (`"s"`), ohne ihn von Hand
  zu tippen: umbenennungssicher; `ex.ParamName` ist `s`.
- `Laenge("abc")`: `s` ist nicht `null`, der `throw` wird nicht ausgewertet: `3`.
- Es geht auch in der Kurzform `ArgumentNullException.ThrowIfNull(s)`.

Typische Fehler: Eine Ausnahme beim zweiten Aufruf erwartet; `ParamName` als die Meldung
gedeutet.

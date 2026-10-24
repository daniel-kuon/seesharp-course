// Ordnet einer Klasse den Typ zu, der ihre Berechnung ausführt.
// Vor C# 11 hätte man dafür [Implementierung(typeof(StandardRechnung))] geschrieben und im
// Konstruktor zur Laufzeit mit typeof(IRechnung).IsAssignableFrom(...) geprüft.
// Jetzt soll das Attribut generisch sein: [Implementierung<StandardRechnung>].
//
// TODO 1: Ableiten von System.Attribute.
// TODO 2: Nur an Klassen erlaubt, nicht mehrfach.
// TODO 3: Die Typeinschränkung 'where T : IRechnung' ersetzt die Laufzeitprüfung des Buchs
//         durch eine Prüfung des Compilers.
// TODO 4: 'Typ' liefert typeof(T).
public class ImplementierungAttribute<T>
{
    public Type Typ => throw new NotImplementedException();
}

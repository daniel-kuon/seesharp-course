// Generisches Attribut (seit C# 11): Der Typ steht als Typargument, nicht als typeof-Parameter.
// Die Einschränkung 'where T : IRechnung' prüft schon der Compiler; die Laufzeitprüfung
// mit IsAssignableFrom aus Buch 14.7.1 entfällt.
[AttributeUsage(AttributeTargets.Class)]
public sealed class ImplementierungAttribute<T> : Attribute where T : IRechnung
{
    public Type Typ => typeof(T);
}

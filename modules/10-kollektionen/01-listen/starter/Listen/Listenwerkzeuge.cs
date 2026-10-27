public static class Listenwerkzeuge
{
    // Entfernt alle geraden Zahlen aus der Liste selbst.
    // Achtung: Bei aufeinanderfolgenden geraden Zahlen versagen foreach und eine
    // Vorwärtsschleife mit RemoveAt(). Laufe mit einer for-Schleife rückwärts.
    public static void RemoveEvens(List<int> zahlen)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Fügt wert in eine aufsteigend sortierte Liste so ein, dass sie sortiert bleibt.
    public static void InsertSorted(List<int> aufsteigend, int wert)
    {
        // TODO: Position suchen (Schleife) und mit Insert() einfügen.
        throw new NotImplementedException();
    }

    // Verschiebt eintrag an Index 0; ist er noch nicht in der Liste, wird er vorn eingefügt.
    // Er darf nie doppelt vorkommen.
    public static void MoveToFront(List<string> liste, string eintrag)
    {
        // TODO: IndexOf(), RemoveAt(), Insert(0, ...)
        throw new NotImplementedException();
    }

    // Liefert eine NEUE Liste mit den drei größten Werten, größter zuerst.
    // Das Argument bleibt unverändert (erst kopieren). Bei weniger als drei Werten
    // kommen alle zurück.
    public static List<int> Top3(List<int> zahlen)
    {
        // TODO: Kopie, Sort(), Reverse(), GetRange()
        throw new NotImplementedException();
    }

    // Liefert ein neues Array, das um k Stellen nach links gedreht ist.
    // {1,2,3,4,5} um 2 -> {3,4,5,1,2}. Das Argument bleibt unverändert.
    // k darf größer als die Länge sein; ein leeres Array bleibt leer.
    public static int[] Rotate(int[] a, int k)
    {
        // TODO: in eine List<int> kopieren, RemoveAt(0) und Add(), mit ToArray() zurückgeben.
        throw new NotImplementedException();
    }
}

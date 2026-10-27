public static class Listenwerkzeuge
{
    // Entfernt alle geraden Zahlen aus der Liste selbst.
    public static void RemoveEvens(List<int> zahlen)
    {
        // Rückwärts: RemoveAt(i) verschiebt nur Elemente, die schon geprüft sind.
        for (int i = zahlen.Count - 1; i >= 0; i--)
            if (zahlen[i] % 2 == 0)
                zahlen.RemoveAt(i);
    }

    // Fügt wert in eine aufsteigend sortierte Liste so ein, dass sie sortiert bleibt.
    public static void InsertSorted(List<int> aufsteigend, int wert)
    {
        int i = 0;
        while (i < aufsteigend.Count && aufsteigend[i] < wert)
            i++;
        aufsteigend.Insert(i, wert);
    }

    // Verschiebt eintrag an Index 0; ist er noch nicht in der Liste, wird er vorn eingefügt.
    public static void MoveToFront(List<string> liste, string eintrag)
    {
        int index = liste.IndexOf(eintrag);
        if (index >= 0)
            liste.RemoveAt(index);
        liste.Insert(0, eintrag);
    }

    // Liefert eine NEUE Liste mit den drei größten Werten, größter zuerst.
    // Das Argument bleibt unverändert.
    public static List<int> Top3(List<int> zahlen)
    {
        var kopie = new List<int>(zahlen);
        kopie.Sort();
        kopie.Reverse();
        return kopie.GetRange(0, Math.Min(3, kopie.Count));
    }

    // Liefert ein neues Array, das um k Stellen nach links gedreht ist.
    // {1,2,3,4,5} um 2 -> {3,4,5,1,2}. Das Argument bleibt unverändert.
    public static int[] Rotate(int[] a, int k)
    {
        var liste = new List<int>(a);
        if (liste.Count == 0)
            return liste.ToArray();
        k %= liste.Count;
        for (int i = 0; i < k; i++)
        {
            int erstes = liste[0];
            liste.RemoveAt(0);
            liste.Add(erstes);
        }
        return liste.ToArray();
    }
}

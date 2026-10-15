public class Fehlersuche {
    // 100 Euro bei Teilbarkeit durch 13; 1 Euro, wenn nicht durch 13, aber durch 7 teilbar; sonst 0.
    // Die Einrückung zeigt die Absicht, aber der Compiler sieht es anders.
    public static int Gewinn(int losNr) {
        int gewinn = 0;
        if (losNr % 13 != 0)
            if (losNr % 7 == 0)
                gewinn = 1;
        else
            gewinn = 100;
        return gewinn;
    }

    // "b ist False" oder "b ist True"
    public static string Beschreibe(bool b) {
        if (b = false)
            return "b ist False";
        else
            return "b ist True";
    }
}

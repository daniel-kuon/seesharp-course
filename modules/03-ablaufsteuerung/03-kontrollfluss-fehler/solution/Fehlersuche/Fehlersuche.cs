public class Fehlersuche {
    public static int Gewinn(int losNr) {
        if (losNr % 13 == 0)
            return 100;
        else if (losNr % 7 == 0)
            return 1;
        else
            return 0;
    }

    public static string Beschreibe(bool b) {
        if (b == false)
            return "b ist False";
        else
            return "b ist True";
    }
}

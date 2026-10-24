public static class Mathe
{
    // n! als long. Die Rechnung selbst ist vorgegeben (checked: Überlauf wird zur OverflowException).
    // TODO: n < 0: eine FakultaetArgumentException(n) werfen.
    // TODO: Für n > 20 löst die checked-Rechnung eine OverflowException aus. Fange sie ab und werfe
    //       stattdessen FakultaetArgumentException(n, ex), sodass die ursprüngliche Ausnahme als
    //       InnerException erhalten bleibt.
    public static long Fakultaet(int n)
    {
        long ergebnis = 1;
        for (int i = 2; i <= n; i++)
            ergebnis = checked(ergebnis * i);
        return ergebnis;
    }

    // Dasselbe ohne eigene Klasse: Für n < 0 und n > 20 wird eine gewöhnliche ArgumentException
    // (genau diese Klasse) geworfen, die das Argument in der Data-Kollektion mitführt:
    // ex.Data["Argument"] = n;
    public static long FakultaetMitData(int n)
    {
        // TODO
        throw new NotImplementedException();
    }
}

public static class Mathe
{
    // n! als long.
    // - n < 0: FakultaetArgumentException(n)
    // - n > 20: Das Ergebnis passt nicht in ein long. Die OverflowException der checked-Rechnung
    //   wird als InnerException in eine FakultaetArgumentException verpackt.
    public static long Fakultaet(int n)
    {
        if (n < 0)
            throw new FakultaetArgumentException(n);
        try
        {
            long ergebnis = 1;
            for (int i = 2; i <= n; i++)
                ergebnis = checked(ergebnis * i);
            return ergebnis;
        }
        catch (OverflowException ex)
        {
            throw new FakultaetArgumentException(n, ex);
        }
    }

    // Dasselbe ohne eigene Klasse: eine gewöhnliche ArgumentException, die das Argument
    // in der Data-Kollektion mitführt. Ungültig sind n < 0 und n > 20.
    public static long FakultaetMitData(int n)
    {
        if (n < 0 || n > 20)
        {
            var ex = new ArgumentException("Fakultät nur für n von 0 bis 20 definiert");
            ex.Data["Argument"] = n;
            throw ex;
        }
        long ergebnis = 1;
        for (int i = 2; i <= n; i++)
            ergebnis *= i;
        return ergebnis;
    }
}

public class Gemischt
{
    [MeinTest] public void B_ok() { }
    [MeinTest] public void A_ok() { }
    [MeinTest] public void C_wirft() => throw new InvalidOperationException("kaputt");

    public void Hilfsmethode() => throw new InvalidOperationException("darf nie laufen");   // kein [MeinTest]
    [MeinTest] public void MitParameter(int x) => throw new InvalidOperationException("darf nie laufen");
    [MeinTest] public static void Statisch() => throw new InvalidOperationException("darf nie laufen");
    [MeinTest] void Privat() => throw new InvalidOperationException("darf nie laufen");
}

public class Gemeinsam
{
    int aufrufe;

    [MeinTest] public void A_Eins() => aufrufe++;
    [MeinTest] public void B_Zwei() { if (aufrufe != 1) throw new InvalidOperationException("andere Instanz oder falsche Reihenfolge"); aufrufe++; }
    [MeinTest] public void C_Drei() { if (aufrufe != 2) throw new InvalidOperationException("andere Instanz oder falsche Reihenfolge"); }
}

public class AlleWerfen
{
    [MeinTest] public void X() => throw new Exception("x");
    [MeinTest] public void Y() => throw new ArgumentException("y");
}

public class OhneTests
{
    public void Nichts() { }
}

public class TestlaeuferTests
{
    [Fact]
    public void Liefert_pro_Test_Name_und_Ergebnis_nach_Namen_sortiert()
    {
        var ergebnis = Laeufer.Starte(typeof(Gemischt));

        Assert.Equal(new[] { ("A_ok", true), ("B_ok", true), ("C_wirft", false) }, ergebnis);
    }

    [Fact]
    public void Nur_oeffentliche_parameterlose_Instanzmethoden_mit_Attribut_zaehlen()
    {
        var namen = Laeufer.Starte(typeof(Gemischt)).Select(e => e.Name);

        Assert.DoesNotContain("Hilfsmethode", namen);
        Assert.DoesNotContain("MitParameter", namen);
        Assert.DoesNotContain("Statisch", namen);
        Assert.DoesNotContain("Privat", namen);
    }

    [Fact]
    public void Alle_Tests_laufen_auf_derselben_Instanz_in_Namensreihenfolge()
    {
        var ergebnis = Laeufer.Starte(typeof(Gemeinsam));

        Assert.Equal(new[] { ("A_Eins", true), ("B_Zwei", true), ("C_Drei", true) }, ergebnis);
    }

    [Fact]
    public void Eine_Ausnahme_bricht_die_uebrigen_Tests_nicht_ab()
    {
        var ergebnis = Laeufer.Starte(typeof(AlleWerfen));

        Assert.Equal(new[] { ("X", false), ("Y", false) }, ergebnis);
    }

    [Fact]
    public void Eine_Klasse_ohne_Tests_ergibt_eine_leere_Liste()
    {
        Assert.Empty(Laeufer.Starte(typeof(OhneTests)));
    }
}

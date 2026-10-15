public class PunktTests
{
    [Fact]
    public void Punkt_ist_ein_Werttyp()
    {
        Assert.True(typeof(Punkt).IsValueType);
    }

    [Fact]
    public void Zuweisung_kopiert_die_Struktur()
    {
        var p1 = new Punkt(1, 2);
        var p3 = p1;

        p1.Bewegen(1, 0);

        Assert.Equal((2.0, 2.0), (p1.X, p1.Y));
        Assert.Equal((1.0, 2.0), (p3.X, p3.Y));
    }

    [Fact]
    public void Parameterloser_Konstruktor_liefert_den_Ursprung()
    {
        var p = new Punkt();

        Assert.Equal("(0; 0)", p.Pos());
    }

    [Fact]
    public void Verschoben_laesst_das_Argument_unveraendert()
    {
        var p = new Punkt(1, 1);

        var q = Punkt.Verschoben(p, 2, 3);

        Assert.Equal((3.0, 4.0), (q.X, q.Y));
        Assert.Equal((1.0, 1.0), (p.X, p.Y));
    }

    [Fact]
    public void Geboxte_Kopien_sind_unabhaengig()
    {
        var p = new Punkt(5, 5);
        object box = p;          // Boxing: Kopie auf dem Heap

        p.Bewegen(1, 1);

        var entpackt = (Punkt)box; // Unboxing
        Assert.Equal((5.0, 5.0), (entpackt.X, entpackt.Y));
    }
}

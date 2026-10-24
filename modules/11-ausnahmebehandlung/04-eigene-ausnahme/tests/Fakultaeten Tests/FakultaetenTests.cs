public class FakultaetenTests
{
    [Fact]
    public void Eigene_Ausnahme_erbt_von_ArgumentException()
    {
        Assert.Equal(typeof(ArgumentException), typeof(FakultaetArgumentException).BaseType);
    }

    [Fact]
    public void Konstruktor_mit_Argument_setzt_Eigenschaft_und_Standardmeldung()
    {
        var ex = new FakultaetArgumentException(-3);

        Assert.Equal(-3, ex.Argument);
        Assert.Equal("Fakultät nicht definiert für -3", ex.Message);
        Assert.Null(ex.InnerException);
    }

    [Fact]
    public void Konstruktor_mit_innerer_Ausnahme_behaelt_sie()
    {
        var ursache = new OverflowException();

        var ex = new FakultaetArgumentException(25, ursache);

        Assert.Equal(25, ex.Argument);
        Assert.Same(ursache, ex.InnerException);
        Assert.Equal("Fakultät von 25 ist zu groß", ex.Message);
    }

    [Theory]
    [InlineData(0, 1L)]
    [InlineData(1, 1L)]
    [InlineData(5, 120L)]
    [InlineData(20, 2432902008176640000L)]
    public void Fakultaet_liefert_gueltige_Ergebnisse(int n, long erwartet)
    {
        Assert.Equal(erwartet, Mathe.Fakultaet(n));
    }

    [Fact]
    public void Fakultaet_wirft_fuer_negative_Zahlen_die_eigene_Ausnahme()
    {
        var ex = Assert.Throws<FakultaetArgumentException>(() => Mathe.Fakultaet(-3));

        Assert.Equal(-3, ex.Argument);
        Assert.Equal("Fakultät nicht definiert für -3", ex.Message);
        Assert.Null(ex.InnerException);
    }

    [Theory]
    [InlineData(21)]
    [InlineData(25)]
    [InlineData(100)]
    public void Fakultaet_verpackt_den_Ueberlauf_als_InnerException(int n)
    {
        var ex = Assert.Throws<FakultaetArgumentException>(() => Mathe.Fakultaet(n));

        Assert.Equal(n, ex.Argument);
        Assert.IsType<OverflowException>(ex.InnerException);
    }

    [Fact]
    public void Wer_ArgumentException_faengt_faengt_auch_die_eigene_Ausnahme()
    {
        var ex = Assert.ThrowsAny<ArgumentException>(() => Mathe.Fakultaet(-1));

        Assert.IsType<FakultaetArgumentException>(ex);
    }

    [Theory]
    [InlineData(0, 1L)]
    [InlineData(6, 720L)]
    [InlineData(20, 2432902008176640000L)]
    public void FakultaetMitData_liefert_gueltige_Ergebnisse(int n, long erwartet)
    {
        Assert.Equal(erwartet, Mathe.FakultaetMitData(n));
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(21)]
    public void FakultaetMitData_wirft_eine_gewoehnliche_ArgumentException_mit_Data(int n)
    {
        var ex = Assert.Throws<ArgumentException>(() => Mathe.FakultaetMitData(n));

        Assert.True(ex.Data.Contains("Argument"));
        Assert.Equal((object)n, ex.Data["Argument"]);
    }
}

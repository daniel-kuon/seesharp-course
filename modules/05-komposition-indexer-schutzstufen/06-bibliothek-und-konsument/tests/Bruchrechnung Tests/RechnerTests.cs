using System.Reflection;
using de.bebagoe.fraction;

public class RechnerTests
{
    [Fact]
    public void Bruch_liegt_im_Namensraum_der_Bibliothek_und_ist_oeffentlich()
    {
        Assert.Equal("de.bebagoe.fraction", typeof(Bruch).Namespace);
        Assert.True(typeof(Bruch).IsPublic);
        Assert.Equal("FractionLib", typeof(Bruch).Assembly.GetName().Name);
    }

    [Fact]
    public void Ggt_ist_internal_und_von_aussen_unsichtbar()
    {
        var oeffentlich = typeof(Bruch).GetMethod("Ggt", BindingFlags.Public | BindingFlags.Static);
        var intern = typeof(Bruch).GetMethod("Ggt", BindingFlags.NonPublic | BindingFlags.Static);

        Assert.Null(oeffentlich);
        Assert.NotNull(intern);
        Assert.True(intern!.IsAssembly, "Ggt muss internal sein");
    }

    [Fact]
    public void Summe_addiert_alle_Brueche_gekuerzt()
    {
        var s = Rechner.Summe(new Bruch(1, 2, "a"), new Bruch(1, 3, "b"), new Bruch(1, 6, "c"));

        Assert.Equal("1/1", s.ToString());
        Assert.Equal("Summe", s.Etikett);
    }

    [Fact]
    public void Summe_laesst_die_Argumente_unveraendert()
    {
        var a = new Bruch(1, 2, "a");

        Rechner.Summe(a, new Bruch(1, 4, "b"));

        Assert.Equal("1/2", a.ToString());
        Assert.Equal("a", a.Etikett);
    }

    [Fact]
    public void Mittel_teilt_die_Summe_durch_die_Anzahl()
    {
        var m = Rechner.Mittel(new Bruch(1, 2, "a"), new Bruch(1, 4, "b"));

        Assert.Equal("3/8", m.ToString());
        Assert.Equal("Mittel", m.Etikett);
    }
}

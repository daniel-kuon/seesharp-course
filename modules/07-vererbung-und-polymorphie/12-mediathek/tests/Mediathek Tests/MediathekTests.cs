using System.Reflection;

public class MediathekTests
{
    [Fact]
    public void Leihfrist_haengt_vom_Laufzeittyp_ab()
    {
        Medium[] bestand = [new Buch("Faust", "Goethe"), new Bestseller("Der Schwarm", "Schätzing"), new Film("Metropolis", 153)];

        Assert.Equal(28, bestand[0].Leihfrist);
        Assert.Equal(14, bestand[1].Leihfrist);
        Assert.Equal(7, bestand[2].Leihfrist);
    }

    [Fact]
    public void Mahngebuehren_je_Medium()
    {
        Medium buch = new Buch("Faust", "Goethe");
        Medium film = new Film("Metropolis", 153);

        Assert.Equal(1.50m, buch.Mahngebuehr(3));
        Assert.Equal(10m, buch.Mahngebuehr(30));
        Assert.Equal(6m, film.Mahngebuehr(3));
        Assert.Equal(20m, film.Mahngebuehr(15));
        Assert.Equal(0m, film.Mahngebuehr(0));
        Assert.Equal(0m, film.Mahngebuehr(-2));
    }

    [Fact]
    public void Bestseller_verdoppelt_die_Mahngebuehr_des_Buchs()
    {
        Medium b = new Bestseller("Der Schwarm", "Schätzing");

        Assert.Equal(3m, b.Mahngebuehr(3));
        Assert.Equal(20m, b.Mahngebuehr(30));
        Assert.Equal(0m, b.Mahngebuehr(0));
    }

    [Fact]
    public void Info_baut_auf_der_Basisfassung_auf()
    {
        Assert.Equal("Faust (28 Tage), Goethe", new Buch("Faust", "Goethe").Info());
        Assert.Equal("Der Schwarm (14 Tage), Schätzing [Bestseller]", new Bestseller("Der Schwarm", "Schätzing").Info());
        Assert.Equal("Metropolis (7 Tage), 153 min", new Film("Metropolis", 153).Info());
    }

    [Fact]
    public void Bestseller_ist_ab_drei_Ausleihen_gefragt()
    {
        var b = new Bestseller("Der Schwarm", "Schätzing");
        b.Ausleihen();
        b.Ausleihen();

        Assert.False(b.IstGefragt);
        b.Ausleihen();
        Assert.True(b.IstGefragt);
    }

    [Fact]
    public void Ausleihzaehler_ist_protected()
    {
        var feld = typeof(Medium).GetField("ausleihen", BindingFlags.Instance | BindingFlags.NonPublic);

        Assert.NotNull(feld);
        Assert.True(feld!.IsFamily, "ausleihen muss protected sein");
    }

    [Fact]
    public void Film_ist_versiegelt()
    {
        Assert.True(typeof(Film).IsSealed, "Film muss sealed sein");
        Assert.Equal("Film", new Film("Nosferatu", 94).GetType().Name);
    }
}

public class CacheTests
{
    [Fact]
    public void TKey_ist_auf_IComparable_eingeschraenkt()
    {
        var tkey = typeof(Cache<,>).GetGenericArguments()[0];

        Assert.Contains(tkey.GetGenericParameterConstraints(),
            c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IComparable<>));
    }

    [Fact]
    public void Ungueltige_Kapazitaet_wirft()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Cache<int, int>(0));
        Assert.Equal(4, new Cache<string, int>(4).Kapazitaet);
    }

    [Fact]
    public void Setze_und_Hole()
    {
        var c = new Cache<string, int>(3);
        c.Setze("eins", 1);
        c.Setze("zwei", 2);

        Assert.Equal(2, c.Count);
        Assert.Equal(1, c.HoleOderDefault("eins"));
        Assert.Equal(2, c.HoleOderDefault("zwei"));
        Assert.True(c.Enthaelt("eins"));
        Assert.False(c.Enthaelt("drei"));
    }

    [Fact]
    public void Unbekannter_Schluessel_liefert_default()
    {
        var zahlen = new Cache<string, int>(2);
        var texte = new Cache<int, string>(2);

        Assert.Equal(0, zahlen.HoleOderDefault("fehlt"));
        Assert.Null(texte.HoleOderDefault(42));
    }

    [Fact]
    public void Setze_ersetzt_einen_vorhandenen_Eintrag()
    {
        var c = new Cache<string, int>(2);
        c.Setze("a", 1);
        c.Setze("a", 10);

        Assert.Equal(1, c.Count);
        Assert.Equal(10, c.HoleOderDefault("a"));
    }

    [Fact]
    public void Voller_Cache_verdraengt_den_am_laengsten_unbenutzten()
    {
        var c = new Cache<int, string>(3);
        c.Setze(1, "a");
        c.Setze(2, "b");
        c.Setze(3, "c");
        c.Setze(4, "d");

        Assert.Equal(3, c.Count);
        Assert.False(c.Enthaelt(1));
        Assert.Equal([2, 3, 4], c.Schluessel());
    }

    [Fact]
    public void Hole_zaehlt_als_Benutzung()
    {
        var c = new Cache<char, int>(3);
        c.Setze('a', 1);
        c.Setze('b', 2);
        c.Setze('c', 3);

        c.HoleOderDefault('a');   // a ist jetzt zuletzt benutzt, b am längsten unbenutzt
        c.Setze('b', 20);         // Ersetzen zählt auch: jetzt ist c am längsten unbenutzt
        c.Setze('d', 4);          // verdrängt c

        Assert.Equal(['a', 'b', 'd'], c.Schluessel());
        Assert.Equal(20, c.HoleOderDefault('b'));
        Assert.Equal(0, c.HoleOderDefault('c'));
    }

    [Fact]
    public void Enthaelt_zaehlt_nicht_als_Benutzung()
    {
        var c = new Cache<string, double>(2);
        c.Setze("x", 1.0);
        c.Setze("y", 2.0);

        Assert.True(c.Enthaelt("x"));
        c.Setze("z", 3.0);        // x bleibt am längsten unbenutzt und fliegt

        Assert.Equal(["y", "z"], c.Schluessel());
    }
}

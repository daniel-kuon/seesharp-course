using System.Reflection;

public class Wertung
{
    [Pflicht]
    [Bereich(1, 10)]
    public int? Punkte { get; set; }

    public int Ungeprueft { get; set; } = 999;
}

public class ValidierungTests
{
    static AttributeUsageAttribute Verwendung(Type t)
    {
        var verwendung = t.GetCustomAttribute<AttributeUsageAttribute>();
        Assert.NotNull(verwendung);
        return verwendung!;
    }

    [Theory]
    [InlineData(typeof(PflichtAttribute))]
    [InlineData(typeof(BereichAttribute))]
    public void Attribute_gelten_nur_fuer_Eigenschaften_und_nicht_mehrfach(Type attribut)
    {
        var v = Verwendung(attribut);

        Assert.Equal(AttributeTargets.Property, v.ValidOn);
        Assert.False(v.AllowMultiple);
    }

    [Fact]
    public void Gueltige_Person_ergibt_keine_Fehler()
    {
        Assert.Empty(Validierer.Pruefe(new Person { Name = "Anna", Alter = 30, Ort = null }));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Fehlender_Name_wird_gemeldet(string? name)
    {
        var fehler = Validierer.Pruefe(new Person { Name = name, Alter = 30 });

        Assert.Equal(new[] { "Name: ist ein Pflichtfeld" }, fehler);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(121)]
    public void Alter_ausserhalb_des_Bereichs_wird_gemeldet(int alter)
    {
        var fehler = Validierer.Pruefe(new Person { Name = "Anna", Alter = alter });

        Assert.Equal(new[] { "Alter: muss zwischen 0 und 120 liegen" }, fehler);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(120)]
    public void Die_Grenzen_des_Bereichs_gehoeren_dazu(int alter)
    {
        Assert.Empty(Validierer.Pruefe(new Person { Name = "Anna", Alter = alter }));
    }

    [Fact]
    public void Mehrere_Fehler_kommen_in_der_Reihenfolge_der_Eigenschaften()
    {
        var fehler = Validierer.Pruefe(new Person { Name = "", Alter = 200, Ort = "" });

        Assert.Equal(new[] { "Name: ist ein Pflichtfeld", "Alter: muss zwischen 0 und 120 liegen" }, fehler);
    }

    [Fact]
    public void Eigenschaften_ohne_Attribut_werden_nicht_geprueft()
    {
        Assert.Empty(Validierer.Pruefe(new Wertung { Punkte = 5, Ungeprueft = 12345 }));
    }

    [Fact]
    public void Fehlender_Wert_meldet_nur_die_Pflicht()
    {
        Assert.Equal(new[] { "Punkte: ist ein Pflichtfeld" }, Validierer.Pruefe(new Wertung { Punkte = null }));
    }

    [Fact]
    public void Wert_ausserhalb_meldet_nur_den_Bereich()
    {
        Assert.Equal(new[] { "Punkte: muss zwischen 1 und 10 liegen" }, Validierer.Pruefe(new Wertung { Punkte = 11 }));
    }
}

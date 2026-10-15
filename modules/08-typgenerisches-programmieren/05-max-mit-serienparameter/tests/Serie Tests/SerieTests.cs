using System.Reflection;

public class SerieTests
{
    [Fact]
    public void Max_und_Min_ueber_eine_Serie()
    {
        Assert.Equal(9, Serie.Max(3, 9, 4));
        Assert.Equal("Otto", Serie.Max("Otto", "Anna", "Kurt"));
        Assert.Equal(1.5, Serie.Min(2.5, 1.5, 3.5));
        Assert.Equal(7, Serie.Max(7));
    }

    [Fact]
    public void Serienparameter_akzeptiert_auch_ein_Array()
    {
        int[] werte = [4, 8, 2];

        Assert.Equal(8, Serie.Max(werte));
        Assert.Equal(2, Serie.Min(werte));
    }

    [Fact]
    public void Leere_Serie_wirft_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Serie.Max<int>());
        Assert.Throws<ArgumentException>(() => Serie.Min<string>());
    }

    [Fact]
    public void MaxOderNull_liefert_null_bei_leerer_Serie()
    {
        Assert.Null(Serie.MaxOderNull<int>());
        Assert.Equal(5, Serie.MaxOderNull(1, 5, 3));
        Assert.Equal(2.5, Serie.MaxOderNull(2.5, -1.0));
    }

    [Fact]
    public void MaxOderNull_ist_auf_Werttypen_eingeschraenkt()
    {
        var t = typeof(Serie).GetMethod("MaxOderNull")!.GetGenericArguments()[0];

        Assert.True(t.GenericParameterAttributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint),
            "MaxOderNull braucht where T : struct");
        Assert.Equal(typeof(Nullable<>), typeof(Serie).GetMethod("MaxOderNull")!.ReturnType.GetGenericTypeDefinition());
    }

    [Fact]
    public void Klemme_begrenzt_auf_den_Bereich()
    {
        Assert.Equal(10, Serie.Klemme(15, 0, 10));
        Assert.Equal(0, Serie.Klemme(-3, 0, 10));
        Assert.Equal(5, Serie.Klemme(5, 0, 10));
        Assert.Equal("m", Serie.Klemme("m", "a", "z"));
    }
}

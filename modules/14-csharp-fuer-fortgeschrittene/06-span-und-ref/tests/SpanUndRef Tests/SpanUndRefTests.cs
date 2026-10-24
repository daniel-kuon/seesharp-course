using System.Runtime.CompilerServices;
using SpanUndRef;

public class SpanUndRefTests
{
    [Fact]
    public void Summe_nimmt_Spans_entgegen()
    {
        var m = typeof(Spans).GetMethod("Summe")!;
        Assert.Equal(typeof(ReadOnlySpan<int>), m.GetParameters()[0].ParameterType);
    }

    [Fact]
    public void Summe_ueber_Array_Ausschnitt_und_stackalloc()
    {
        int[] a = [1, 2, 3, 4, 5, 6];
        Assert.Equal(21, Spans.Summe(a));
        Assert.Equal(3 + 4 + 5, Spans.Summe(a.AsSpan(2, 3)));
        Assert.Equal(0, Spans.Summe([]));

        Span<int> puffer = stackalloc int[4];
        for (int i = 0; i < puffer.Length; i++) puffer[i] = i + 1;
        Assert.Equal(10, Spans.Summe(puffer));
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("   ", 0)]
    [InlineData("eins", 1)]
    [InlineData("eins zwei drei", 3)]
    [InlineData("  eins   zwei  ", 2)]
    public void ZaehleWoerter_zaehlt_Woerter(string text, int erwartet)
    {
        Assert.Equal(erwartet, Spans.ZaehleWoerter(text));
    }

    [Fact]
    public void ZaehleWoerter_arbeitet_auch_auf_einem_Ausschnitt()
    {
        char[] zeichen = "ab cd ef gh".ToCharArray();
        Assert.Equal(2, Spans.ZaehleWoerter(zeichen.AsSpan(3, 5))); // "cd ef"
        Assert.Equal(1, Spans.ZaehleWoerter("eins zwei".AsSpan(0, 4)));
    }

    [Fact]
    public void SpiegleInPlace_aendert_das_Array()
    {
        var m = typeof(Spans).GetMethod("SpiegleInPlace")!;
        Assert.Equal(typeof(Span<int>), m.GetParameters()[0].ParameterType);

        int[] a = [1, 2, 3, 4, 5];
        Spans.SpiegleInPlace(a);
        Assert.Equal([5, 4, 3, 2, 1], a);
    }

    [Fact]
    public void SpiegleInPlace_wirkt_nur_auf_den_Ausschnitt()
    {
        int[] a = [1, 2, 3, 4, 5];
        Spans.SpiegleInPlace(a.AsSpan(1, 3));
        Assert.Equal([1, 4, 3, 2, 5], a);
        Spans.SpiegleInPlace(a.AsSpan(0, 0));
        Spans.SpiegleInPlace(a.AsSpan(2, 1));
        Assert.Equal([1, 4, 3, 2, 5], a);
    }

    [Fact]
    public void Hoechster_gibt_einen_Verweis_zurueck()
    {
        Assert.True(typeof(Spans).GetMethod("Hoechster")!.ReturnType.IsByRef);

        int[] a = [3, 9, 4, 9, 1];
        ref int h = ref Spans.Hoechster(a);
        Assert.Equal(9, h);
        Assert.True(Unsafe.AreSame(ref h, ref a[1]));
    }

    [Fact]
    public void Hoechster_kann_zugewiesen_werden()
    {
        int[] a = [3, 9, 4, 2];
        Spans.Hoechster(a) = 0;
        Assert.Equal([3, 0, 4, 2], a);
        Spans.Hoechster(a)++;
        Assert.Equal([3, 0, 5, 2], a);
    }

    [Fact]
    public void Hellster_liefert_einen_schreibgeschuetzten_Verweis()
    {
        Messpunkt[] a = [new(0, 0, 0, 0.2), new(1, 1, 1, 0.9), new(2, 2, 2, 0.5)];
        var typ = typeof(Spans).GetMethod("Hellster")!.ReturnParameter;
        Assert.True(typ.ParameterType.IsByRef);
        Assert.Contains(typ.GetRequiredCustomModifiers(), t => t.Name == "InAttribute");

        ref readonly Messpunkt h = ref Spans.Hellster(a);
        Assert.Equal(0.9, h.Helligkeit);
        Assert.True(Unsafe.AreSame(in h, in a[1]));
    }

    [Fact]
    public void IstPalindrom_auf_String_und_Array()
    {
        Assert.True("anna".IstPalindrom());
        Assert.True("".IstPalindrom());
        Assert.True("a".IstPalindrom());
        Assert.True("rentner".IstPalindrom());
        Assert.False("ente".IstPalindrom());
        Assert.False("Anna".IstPalindrom());

        char[] zeichen = ['x', 'a', 'b', 'a', 'y'];
        Assert.False(zeichen.IstPalindrom());
        Assert.True(zeichen.AsSpan(1, 3).IstPalindrom());
    }
}

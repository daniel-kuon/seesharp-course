using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Zeichenstatistik;

public class StatistikTests
{
    [Fact]
    public void ZaehleVokale_in_String_Array_und_Ausschnitt()
    {
        Assert.Equal(0, Statistik.ZaehleVokale(""));
        Assert.Equal(5, Statistik.ZaehleVokale("aeiou"));
        Assert.Equal(4, Statistik.ZaehleVokale("Schöne Grüße"));       // ö, e, ü, e
        Assert.Equal(2, Statistik.ZaehleVokale("AEbcd"));

        char[] zeichen = "xxaexx".ToCharArray();
        Assert.Equal(2, Statistik.ZaehleVokale(zeichen));
        Assert.Equal(0, Statistik.ZaehleVokale(zeichen.AsSpan(0, 2)));
        Assert.Equal(1, Statistik.ZaehleVokale(zeichen.AsSpan(1, 2)));
    }

    [Theory]
    [InlineData("hallo welt", "hallo")]
    [InlineData("  hallo welt", "hallo")]
    [InlineData("eins", "eins")]
    [InlineData("", "")]
    [InlineData("   ", "")]
    public void ErstesWort_liefert_den_Ausschnitt(string text, string erwartet)
    {
        Assert.Equal(erwartet, Statistik.ErstesWort(text).ToString());
    }

    [Fact]
    public void ErstesWort_kopiert_nichts()
    {
        char[] zeichen = "  ab cd".ToCharArray();
        ReadOnlySpan<char> wort = Statistik.ErstesWort(zeichen);
        Assert.Equal(2, wort.Length);
        Assert.True(Unsafe.AreSame(in MemoryMarshal.GetReference(wort), in zeichen[2]));
    }

    [Fact]
    public void Teilsumme_ueber_Array_und_Ausschnitt()
    {
        int[] a = [1, 2, 3, 4, 5];
        Assert.Equal(9, Statistik.Teilsumme(a, 1, 4));
        Assert.Equal(15, Statistik.Teilsumme(a, 0, 5));
        Assert.Equal(0, Statistik.Teilsumme(a, 2, 2));
        Assert.Equal(7, Statistik.Teilsumme(a.AsSpan(1, 3), 1, 3)); // 3 + 4
        Assert.Equal(6, Statistik.Teilsumme([1, 2, 3], 0, 3));
    }

    [Theory]
    [InlineData(-1, 2)]
    [InlineData(0, 6)]
    [InlineData(3, 2)]
    public void Teilsumme_lehnt_ungueltige_Grenzen_ab(int von, int bis)
    {
        int[] a = [1, 2, 3, 4, 5];
        Assert.Throws<ArgumentOutOfRangeException>(() => Statistik.Teilsumme(a, von, bis));
    }
}
